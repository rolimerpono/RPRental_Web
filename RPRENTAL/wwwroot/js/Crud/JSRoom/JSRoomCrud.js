﻿var objDataTable;

$(document).ready(function () {
    initializeDataTable();

    $(".btn-add").click(function () {
        loadModal("/Room/Create", "#modal-add-content");
    });

    $(".btn-save").click(function () {
        saveRoom("/Room/Create", "#form-add");
    });

    $("#tbl_Rooms").on("click", ".select-edit-btn", function () {
        var rowData = getRowData($(this));
        loadModal("/Room/Update", "#modal-edit-content", rowData);
    });

    $(".btn-edit").click(function () {
        saveRoom("/Room/Update", "#form-edit");
    });

    $("#tbl_Rooms").on("click", ".select-delete-btn", function () {
        var rowData = getRowData($(this));
        $("#rooM_ID").val(rowData.rooM_ID);
        $("#modal-delete").modal("show");
    });

    $(".btn-delete").click(function () {
        deleteRoom("#form-delete");
    });
});

function initializeDataTable() {
    objDataTable = $('#tbl_Rooms').DataTable({
        "ajax": {
            url: '/Room/GetAll'
        },
        "columns": [
            { data: 'rooM_ID', visible: false },
            { data: 'rooM_NAME', "width": "15%" },
            { data: 'description', "width": "20%" },
            { data: 'rooM_PRICE', "width": "5%" },
            { data: 'maX_OCCUPANCY', "width": "5%" },
            { data: 'imagE_URL', "width": "5%" },
            {
                data: 'rooM_ID',
                "width": "5%",
                "render": function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                }
            },
            {
                data: 'rooM_ID',
                "width": "5%",
                "render": function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm select-delete-btn w-100">Delete</button>';
                }
            }
        ],
        "columnDefs": [
            { "className": "text-start", "targets": "_all" },
            {
                "targets": [2], "className": "dt-nowrap", "render": function (data, type, row) {
                    return type === 'display' && data.length > 100 ? '<span title="' + data + '">' + data.substr(0, 100) + '...</span>' : data;
                }
            }
        ],
        fixedColumns: true,
        scrollY: true
    });
}

function loadModal(url, modalContentSelector, data = null) {
    
    $.ajax({
        type: "GET",
        url: url,    
        data: data,
        success: function (result) {     
            $(modalContentSelector).html(result);
            $(modalContentSelector.replace("-content", "")).modal("show"); 
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}


function saveRoom(url, formSelector) {
 
    var objRoomData = $(formSelector).serialize();
    $.ajax({
        type: "POST",
        url: url,
        data: objRoomData,
        success: function (response) {
            if ($(formSelector)[0].checkValidity()) {   
                if (response.success) {
                    objDataTable.ajax.reload();
                    $(formSelector.replace("form","modal")).modal("hide");
                    showToast("success", response.message);
                } else {
                    showToast("error", response.message);
                }
            } else {
                $(formSelector).addClass("was-validated");
            }
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}

function deleteRoom(formSelector) {
    var objRoomData = $(formSelector).serialize();
    $.ajax({
        type: "POST",
        url: "/Room/Delete",
        data: objRoomData,
        success: function (response) {
            objDataTable.ajax.reload();
            $("#modal-delete").modal("hide");
            showToast("success", response.message);
        },
        error: function (xhr, status, error) {
            handleAjaxError(error);
        }
    });
}

function getRowData(btn) {
    return objDataTable.row(btn.closest('tr')).data();
}

function handleAjaxError(error) {
    console.log("Error: " + error);
}

function showToast(type, message) {
    var toaster = $("#toaster");
    toaster.text(message);
    toaster.css("display", "block").css("backgroundColor", type === "success" ? "#006400" : "red").css("opacity", 1);
    setTimeout(function () {
        toaster.css("opacity", 0);
        setTimeout(function () {
            toaster.css("display", "none").css("opacity", 1);
        }, 500);
    }, 3000);
}
