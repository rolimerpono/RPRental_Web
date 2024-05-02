﻿let objDataTable;

$(document).ready(function () {

    const urlParams = new URLSearchParams(window.location.search);
    let status = urlParams.get('status') ?? 'Pending';

    $('.btn-checkin').click(function () {    
        checkIn();
    }); 

    $('.btn-checkout').click(function () {
        checkOut();
    }); 

    $('.btn-cancel').click(function () {
        CancelBooking();
    }); 

    $('.btn-payment').click(function () {
        ProceedPayment();
    }); 

    const statusToButtonMap = {
        'all': '#all',
        'pending': '#pending',
        'approved': '#approved',
        'check_in': '#checkin',
        'check_out': '#checkout',
        'cancelled': '#cancelled'
    };

    const updateButtonColor = status => {
        const buttonId = statusToButtonMap[status.toLowerCase()];
        if (buttonId) $(buttonId).toggleClass('btn-primary btn-success');
    };

    updateButtonColor(status);  

    loadBookings(status);

    $('#tbl_Bookings').on('click', '.select-view-btn', function () {     
        var rowData = getRowData($(this));
        loadModal('/Booking/BookingDetails', '#modal-booking-content', rowData);       
    });
  

});

function checkIn() {
    data = $('#booking_detail').serialize();    
        $.ajax({
            type: 'POST',
            url: 'Booking/CheckIn',
            data: data,
            success: function (response) {
                if (response.success) {
                    objDataTable.ajax.reload();
                    $('#modal-booking').modal('hide');
                    showToast('success', response.message);
                } else {
                    showToast('error', response.message);
                }
            },
            error: function (xhr, status, error) {
                handleAjaxError(error);
            }
        });

        $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
            $(modalContentSelector).html('');
        });
}

function checkOut() {
    data = $('#booking_detail').serialize();
    $.ajax({
        type: 'POST',
        url: 'Booking/CheckOut',
        data: data,
        success: function (response) {
            if (response.success) {
                objDataTable.ajax.reload();
                $('#modal-booking').modal('hide');
                showToast('success', response.message);
            } else {
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}

function ProceedPayment() {

    let id = $('#booking_id').val();    

    $.ajax({
        url: '/Booking/ShowPayment',
        method: 'POST',
        data: { BookingId:id },
        success: function (response) {
            
            if (response.success) {

                window.location.href = response.redirectUrl;
            }
            else {
                showToast('error', 'Somethign went wrong : ' + response.message);
            }
        },
        error: function (xhr, status, error) {      
            showToast('error', 'Something went wrong : ' + error);
        }
    });
    
}


function CancelBooking() {
    data = $('#booking_detail').serialize();

    $.ajax({
        type: 'POST',
        url: 'Booking/CancelBooking',
        data: data,
        success: function (response) {
            if (response.success) {
                objDataTable.ajax.reload();
                $('#modal-booking').modal('hide');
                showToast('success', response.message);
            } else {
                showToast('error', response.message);
            }
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}

function getRowData(btn) {
    return objDataTable.row(btn.closest('tr')).data();
}

function loadBookings(status) {
    
    objDataTable = $('#tbl_Bookings').DataTable({
        ajax: {
            url: '/Booking/GetAll?status=' + status
        },
        columns: [
            { data: 'bookingId', visible: false },
            { data: 'userName', width: '5%' },
            { data: 'userEmail', width: '5%' },
            { data: 'bookingStatus', width: '5%' },
            { data: 'checkinDate', width: '5%' },
            { data: 'checkoutDate', width: '5%' },
            { data: 'noOfStay', width: '5%' },
            {
                data: 'totalCost',
                width: '5%',
                render: function (data, type, row) {                   
                    return '$' + parseFloat(data).toFixed(2); 
                }
            },
            {
                data: 'bookingId',
                width: '5%',
                'render': function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-view-btn w-100">View Details</button>';
                }
            },
        ],
        fixedColumns: true,
        scrollY: true,        
        
    });    

}

function loadModal(url, modalContentSelector, data = null) {
    $.ajax({
        type: 'GET',
        url: url,
        data: data,
        success: function (response) {           
            $(modalContentSelector).empty().html(response);
            $(modalContentSelector.replace('-content', '')).modal('show');
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });

    $(document).on('hidden.bs.modal', modalContentSelector.replace('-content', ''), function () {
        $(modalContentSelector).html('');
    });
}

function handleAjaxError(xhr, status, error) {
    showToast('error', 'An error occurred. Please try again later.');
}

function showToast(type, message) {
    const toaster = $('.toaster');
    toaster.text(message).css({
        'display': 'block',
        'background-color': type === 'success' ? '#006400' : 'red',
        'opacity': 1
    });

    setTimeout(() => {
        toaster.css('opacity', 0);
        setTimeout(() => toaster.css('display', 'none').css('opacity', 1), 500);
    }, 3000);
}