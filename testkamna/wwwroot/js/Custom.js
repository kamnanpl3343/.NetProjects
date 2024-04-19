function getPostData(getUrl, fillDivid, formid) {
    $.ajax({
        type: 'POST',
        url: getUrl,
        data: $(formid).serialize(),
        success: function (data) {
            $(fillDivid).html(data);
        }
    }).done(function () {
        //do after done
    });
}

function getPostDataJson(getUrl, formid) {

    $("#" + formid).validate({
        errorClass: "my-error-class",
        validClass: "my-valid-class"
    });

    if (!$("#" + formid).valid()) {
        ShowMessage("Invalid Form Data", false);
        return;
    }
    var myForm = document.getElementById(formid);
    var formData = new FormData(myForm);
    $.ajax({
        type: 'POST',
        url: getUrl,
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            ShowMessage(data.data, data.status);
        }
    }).done(function () {
        //do after done
    });
}

function getData(getUrl, fillDivid) {
    $.ajax({
        type: 'get',
        url: getUrl,
        success: function (data) {
            $(fillDivid).html(data);
        }
    }).done(function () {
        //do after done
    });
}
function FilterData(currentPageNumber, pageSize) {
    $("#Page_PageSize").val(pageSize);
    $("#Page_CurrentPageNumber").val(currentPageNumber);
    Load();
}

function ShowMessage(msg, IsSuccess) {
    if (IsSuccess) { toastr.success(msg); }
    else { toastr.error(msg); }
}