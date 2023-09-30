// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//registration start

let OpenRegistration = (url) => {
    $("#divLoader").show();
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#registermodal .modal-body').html(res);
            $('#registermodal').modal('show');
            $("#divLoader").hide();
        }
    })
}
let RegisterUser = (url) => {
    $("#divLoader").show();
    $.ajax({
        type: 'POST',
        url: url,
        data: $("#frmRegister").serialize(),
        contentType: "application/x-www-form-urlencoded",
        success: function (res) {
            $('#registermodal .modal-body').html(res);
            $('#registermodal').modal('show');
            $("#divLoader").hide();
        }
    })
}
//registration end


//MyFileController start

handleEditUserAccess = (tarUrl) => {       
    $.ajax({
        type: 'GET',
        url: tarUrl,
        success: function (response) {
            $('#ModalUserAccess .modal-body').html(response);
            $('#ModalUserAccess').modal('show');
        }
    })
}

handleAddUserAccess = () => {
    let usermail = document.getElementById('iUserMailAccess').value;

}

handleAddUserFile = () => {
    let tarUrl = document.getElementById("btnAddUserAccess").getAttribute('data-bs-url');
    $.ajax({
        type: 'GET',
        url: tarUrl,
        success: function (response) {
            $('#AddUserFileContainer').html(response);
            $('#AddUserFileModal').modal('show');
        }
    })
}

handleVerifyUser = () => {
    let user = $("#iAddUser").val();
    debugger;
    $.ajax({
        type: 'GET',
        url: `/MyFile/VerifyUser/?usermail='${user}'`,
        success: function (response) {
            if (response) {
                $("#tempUser").append("<li class='list-group-item'>" + user + "</li>");
            }
        }
    })
}
//MyFileController end