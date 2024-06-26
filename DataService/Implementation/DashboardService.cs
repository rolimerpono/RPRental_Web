﻿using DataService.Interface;
using RPRENTAL.ViewModels;
using Utility;
using Stripe.FinancialConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPRENTAL.ViewModels.BarChartDTO;

namespace DataService.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IWorker _IWorker;


        static int previous_month = DateTime.Now.Month == 1 ? 12: DateTime.Now.Month - 1;

        private readonly DateTime previous_month_start_date = new(DateTime.Now.Year, previous_month - 1, 1);
        private readonly DateTime current_month_start_date = new(DateTime.Now.Year,DateTime.Now.Month, 1);

        public DashboardService(IWorker Iworker)
        {
            _IWorker = Iworker;
        }

        public async Task<PieChartDTO> GetCustomerBookingPieChart()
        {
        
            var total_booking = _IWorker.tbl_Booking.GetAll(
              fw => fw.BookingStatus != SD.BookingStatus.Pending.ToString() ||
              fw.BookingStatus == SD.BookingStatus.Cancelled.ToString() && (fw.BookingDate >= DateTime.Now.AddDays(-30)));

            var customer_with_one_booking = total_booking.GroupBy(fw => fw.UserId).Where(fw => fw.Count() == 1).Select(fw => fw.Key).ToList();

            int new_customer_booking = customer_with_one_booking.Count();
            int returning_customer_booking = total_booking.Count() - new_customer_booking;


            PieChartDTO piechart_vm = new PieChartDTO()
            {
                labels = new string[] { "New Customer", "Returning Customer" },
                series = new decimal[] { new_customer_booking, returning_customer_booking}

            };

            return piechart_vm;
        }

        public async Task<BarChartDTO> GetMemberAndBookingBarChartData()
        {
            var booking_data = _IWorker.tbl_Booking.GetAll(fw => fw.BookingDate >= DateTime.Now.AddDays(-30) && fw.BookingDate.Date <= DateTime.Now)
               .GroupBy(fw => fw.BookingDate.Date)
               .Select(f => new
               {
                   DateTime = f.Key,
                   NewBookingCount = f.Count()
               });


            var customer_data = _IWorker.tbl_User.GetAll(fw => fw.CreatedDate >= DateTime.Now.AddDays(-30) && fw.CreatedDate.Value.Date <= DateTime.Now)
                .GroupBy(fw => fw.CreatedDate!.Value.Date)
                .Select(f => new
                {
                    DateTime = f.Key,
                    NewCustomerCount = f.Count()
                });


            var booking_temp = booking_data.GroupJoin(customer_data, booking => booking.DateTime, customer => customer.DateTime,
            (booking, customer) => new
            {
                booking.DateTime,
                booking.NewBookingCount,
                NewCustomerCount = customer.Select(fw => fw.NewCustomerCount).FirstOrDefault()
            });


            var customer_temp = customer_data.GroupJoin(booking_data, customer => customer.DateTime, booking => booking.DateTime,
            (customer, booking) => new
            {
                customer.DateTime,
                NewBookingCount = booking.Select(fw => fw.NewBookingCount).FirstOrDefault(),
                customer.NewCustomerCount

            });



            var merge_data = booking_temp.Union(customer_temp).OrderBy(fw => fw.DateTime).ToList();

            var new_booking_data = merge_data.Select(fw => fw.NewBookingCount).ToArray();
            var new_customer_data = merge_data.Select(fw => fw.NewCustomerCount).ToArray();
            var categories = merge_data.Select(fw => fw.DateTime.ToString("yyy-MM-dd")).ToArray();


            List<ChartData> charList = new List<ChartData>()
            {
                new ChartData
                {
                    Name = "New Booking[s]",
                    Data = new_booking_data
                },
                 new ChartData
                {
                    Name = "New Customer[s]",
                    Data = new_customer_data
                }

            };

            BarChartDTO linechart_data = new BarChartDTO()
            {
                Categories = categories,
                Series = charList
            };

            return linechart_data;
        }

        public async Task<RadialBarChartDTO> GetRegisteredUserRadialChartData()
        {
            var total_user = _IWorker.tbl_User.GetAll();


            var count_current_month = total_user.Count(fw => fw.CreatedDate >= current_month_start_date &&
            fw.CreatedDate <= DateTime.Now);


            var count_previous_month = total_user.Count(fw => fw.CreatedDate >= previous_month_start_date &&
            fw.CreatedDate <= current_month_start_date);


            return GetRadialBarChartDataModel(total_user.Count(), count_current_month, count_previous_month);
        }     

        public async Task<RadialBarChartDTO> GetRevenueRadialChartData()
        {
            var total_booking = _IWorker.tbl_Booking.GetAll(
              fw => fw.BookingStatus != SD.BookingStatus.Pending.ToString() ||
              fw.BookingStatus == SD.BookingStatus.Cancelled.ToString());


            var total_revenue = (Int32)total_booking.Sum(fw => fw.TotalCost);

            var count_current_month = (decimal)total_booking.Where(fw => fw.BookingDate >= current_month_start_date &&
            fw.BookingDate <= DateTime.Now).Sum(fw => fw.TotalCost);


            var count_previous_month = (decimal)total_booking.Where(fw => fw.BookingDate >= previous_month_start_date &&
            fw.BookingDate <= current_month_start_date).Sum(fw => fw.TotalCost);


            return GetRadialBarChartDataModel(total_revenue, count_current_month, count_previous_month);
        }

     

        public async Task<RadialBarChartDTO> GetTotalBookingRadialChartData()
        {
            var total_booking = _IWorker.tbl_Booking.GetAll(
              fw => fw.BookingStatus != SD.BookingStatus.Pending.ToString() ||
              fw.BookingStatus == SD.BookingStatus.Cancelled.ToString());


            var count_current_month = total_booking.Count(fw => fw.BookingDate >= current_month_start_date &&
            fw.BookingDate <= DateTime.Now);


            var count_previous_month = total_booking.Count(fw => fw.BookingDate >= previous_month_start_date &&
            fw.BookingDate <= current_month_start_date);



            return GetRadialBarChartDataModel(total_booking.Count(), count_current_month, count_previous_month);
        }

        public async Task<PieChartDTO> GetOverAllBokingsPieChartData()
        {
            var total_booking = _IWorker.tbl_Booking.GetAll();

            int total_pending = total_booking.Where(fw => (fw.BookingStatus == SD.BookingStatus.Pending.ToString())
            && (fw.BookingDate >= current_month_start_date) && (fw.BookingDate <= DateTime.Now)).Count();

            int total_approved = total_booking.Where(fw => (fw.BookingStatus == SD.BookingStatus.Approved.ToString())
            && (fw.BookingDate >= current_month_start_date) && (fw.BookingDate <= DateTime.Now)).Count();

            int total_checkin = total_booking.Where(fw => (fw.BookingStatus == SD.BookingStatus.Checkin.ToString())
            && (fw.BookingDate >= current_month_start_date) && (fw.BookingDate <= DateTime.Now)).Count();

            int total_checkout = total_booking.Where(fw => (fw.BookingStatus == SD.BookingStatus.Checkout.ToString())
            && (fw.BookingDate >= current_month_start_date) && (fw.BookingDate <= DateTime.Now)).Count();

            int total_cancelled = total_booking.Where(fw => (fw.BookingStatus == SD.BookingStatus.Cancelled.ToString())
            && (fw.BookingDate >= current_month_start_date) && (fw.BookingDate <= DateTime.Now)).Count();



            PieChartDTO piechart_vm = new PieChartDTO()
            {
                labels = new string[] { "Pending", "Approved", "Check In", "Check Out", "Cancelled" },
                series = new decimal[] { total_pending, total_approved, total_checkin, total_checkout, total_cancelled }

            };

            return piechart_vm;
        }

        public static RadialBarChartDTO GetRadialBarChartDataModel(int total_count, decimal current_month_count, decimal previous_month_count)
        {

            RadialBarChartDTO radialbarchar_dto = new RadialBarChartDTO();



            int increase_decreaseration = 100;

            if (previous_month_count != 0)
            {

                increase_decreaseration = Convert.ToInt32(current_month_count - previous_month_count / previous_month_count * 100);

            }

            radialbarchar_dto.TotalCount = total_count;
            radialbarchar_dto.CountInCurrentMonth = current_month_count;
            radialbarchar_dto.HasRationIncreased = current_month_count > previous_month_count;
            radialbarchar_dto.Series = new int[] { increase_decreaseration };

            return radialbarchar_dto;

        }

      
    }
}
