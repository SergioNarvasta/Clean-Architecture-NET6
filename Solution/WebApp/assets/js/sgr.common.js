
$("#CountryId").change(function () {
    var selectedCountry = $('#CountryId').val();
    if (selectedCountry == 0) {
        disableDemographicCombo("Country");
    } else {
        fillDemographicCombo("CountryId", "DepartmentId", "Department");
    }
});

$("#DepartmentId").change(function () {
    var selectedDepartment = $('#DepartmentId').val();
    if (selectedDepartment == 0) {
        disableDemographicCombo("Department");
    } else {
        fillDemographicCombo("DepartmentId", "ProvinceId", "Province");
    }
});

$("#ProvinceId").change(function () {
    var selectedProvince = $('#ProvinceId').val();
    if (selectedProvince == 0) {
        disableDemographicCombo("Province");
    } else {
        fillDemographicCombo("ProvinceId", "DistrictId", "District");
    }
});

function disableDemographicCombo(typeValue) {
    if (typeValue == "Country") {
        $("#DepartmentId").empty();
        $("#DepartmentId").append('<option value="">Seleccionar</option>');
    }

    if (typeValue == "Country" || typeValue == "Department") {
        $("#ProvinceId").empty();
        $("#ProvinceId").append('<option value="">Seleccionar</option>');
    }

    if (typeValue == "Country" || typeValue == "Department" || typeValue == "Province") {
        $("#DistrictId").empty();
        $("#DistrictId").append('<option value="">Seleccionar</option>');
    }
}

function fillDemographicCombo(selectedDropdown, destinationDropdown, typeValue) {
    var selectedId = $('#' + selectedDropdown + '').val();
    if (selectedId > 0) {
        $("#" + destinationDropdown).empty();
        $("#" + destinationDropdown).append('<option value="">Seleccionar</option>');
        $.ajax({
            type: 'POST',
            url: '/Common/GetDemographics',
            dataType: 'json',
            data: { parameterId: selectedId, type: typeValue },
            success: function (response) {
                if (response.success) {
                    $.each(response.responseText, function (i, response) {
                        var dropDownData = '<option value="' + response.Value + '">' + response.Text + '</option>';
                        $("#" + destinationDropdown).append(dropDownData);
                    });
                    $("#" + destinationDropdown).prop("disabled", false);
                } else {
                    $("#" + destinationDropdown).prop("disabled", true);
                }
            },
            error: function (ex) {
                alert(ex.statusText);
            }
        });
    } else {
        $("#" + destinationDropdown).prop("disabled", true);
    }
}

function enableDepartmentCombo() {
    var countryIdSelected = $('#CountryId').val();
    var disableDepartmentCombo = countryIdSelected > 0 ? false : true;
    $("#DepartmentId").prop("disabled", disableDepartmentCombo);
}

function enableProvinceCombo() {
    var departmentIdSelected = $('#DepartmentId').val();
    var disableProvinceCombo = departmentIdSelected > 0 ? false : true;
    $("#ProvinceId").prop("disabled", disableProvinceCombo);
}

function enableDistrictCombo() {
    var districtIdSelected = $('#DistrictId').val();
    var disableDistrictCombo = districtIdSelected > 0 ? false : true;
    $("#DistrictId").prop("disabled", disableDistrictCombo);
}

function showSuccessNotification(message) {
    var messageText = message;
    if (messageText != "") {
        $.notify(messageText, {
            // whether to hide the notification on click
            clickToHide: false,
            // whether to auto-hide the notification
            autoHide: true,
            // if autoHide, hide after milliseconds
            autoHideDelay: 5000,
            // show the arrow pointing at the element
            arrowShow: true,
            // arrow size in pixels
            arrowSize: 5,
            // position defines the notification position though uses the defaults below
            position: 'bottom right',
            // default positions
            elementPosition: 'bottom right',
            globalPosition: 'bottom right',
            // default style
            style: 'bootstrap',
            // default class (string or [string])
            className: 'success',
            // show animation
            showAnimation: 'slideDown',
            // show animation duration
            showDuration: 400,
            // hide animation
            hideAnimation: 'slideUp',
            // hide animation duration
            hideDuration: 200,
            // padding between element and notification
            gap: 5
        });
    }
}

function showErrorNotification(message) {
    var messageText = message;
    if (messageText != "") {
        $.notify(messageText, {
            // whether to hide the notification on click
            clickToHide: false,
            // whether to auto-hide the notification
            autoHide: true,
            // if autoHide, hide after milliseconds
            autoHideDelay: 5000,
            // show the arrow pointing at the element
            arrowShow: true,
            // arrow size in pixels
            arrowSize: 5,
            // position defines the notification position though uses the defaults below
            position: 'bottom right',
            // default positions
            elementPosition: 'bottom right',
            globalPosition: 'bottom right',
            // default style
            style: 'bootstrap',
            // default class (string or [string])
            className: 'error',
            // show animation
            showAnimation: 'slideDown',
            // show animation duration
            showDuration: 400,
            // hide animation
            hideAnimation: 'slideUp',
            // hide animation duration
            hideDuration: 200,
            // padding between element and notification
            gap: 5
        });
    }
}

function blockUI() {
    console.log("blockUI");
    $.blockUI({
        message: "Porfavor Espere...",
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
    });
}

function unblockUI() {
    console.log("unblockUI");
    $.unblockUI();
}