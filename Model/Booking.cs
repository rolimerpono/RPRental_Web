﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Booking
    {
        public Booking()
        {
           

        }

        [Key]
        public int  BOOKING_ID { get;set; } 

        [Required]
        public string USER_ID { get;set; }

        [ForeignKey("USER_ID")]
        public ApplicationUser? USERS { get; set; }

        [Required]
        public int ROOM_ID { get;set; }

        [ForeignKey("ROOM_ID")]
        public Room? ROOM { get;set; }      

        public int ROOM_NUMBER { get; set; }

        [Required]
        public string USER_NAME { get; set; }

        [Required]
        public string USER_EMAIL { get; set;}

        public string? PHONE_NUMBER { get; set; }

        [Required]
        public double TOTAL_COST { get; set; }      

        public string? BOOKING_STATUS { get; set; }

        [Required]
        public  DateTime BOOKING_DATE { get; set; } = DateTime.Now;


        [Required]
        public DateOnly CHECK_IN_DATE { get; set; }

        [Required]
        public  DateOnly CHECK_OUT_DATE { get; set; } 

        public Boolean IS_PAYMENT_SUCCESSFULL { get; set; } = false;

        public DateTime PAYMENT_DATE { get; set; } 

        public string? STRIPE_SESSION_ID { get; set; }

        public string? STRIPE_PAYEMENT_INTENT_ID { get; set; }

        public DateTime ACTUAL_CHECK_IN_DATE { get; set; }

        public DateTime ACTUAL_CHECK_OUT_DATE { get; set; }

      
        [NotMapped]
        public IEnumerable<RoomAmenity> ROOM_AMENITY { get; set; }

        [ValidateNever]
        [NotMapped]
        public List<string> ROOM_NUMBER_LIST { get; set; }

        [ValidateNever]
        [NotMapped]
        public int NO_OF_STAY { get; set; }















    }
}
