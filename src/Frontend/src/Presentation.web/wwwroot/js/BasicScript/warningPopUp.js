﻿// Pop-up window for warning to delete the account

function WarningPopUp(event, form, url, title, message) {

    Swal.fire({
        title: title,
        text: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm',
        cancelButtonText: 'Cancel',
        background: '#1e1e1e',
        color: '#fff',
        iconColor: '#ffd6a5',
    }).then((result) => {
        if (result.isConfirmed) {
            if (url == "") {
                document.getElementById(form).submit();
            } else {
                window.location.href = url;
            }
        }
    }); 
}
