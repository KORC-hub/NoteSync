

function DeleteUser(event, url) {
    //event.preventDefault(); // Evita la redirección por defecto
    //if (confirm("Are you sure to delete your account, this will also delete all your folders.")) {
    //    // Si el usuario acepta, redirige al controlador
    //    window.location.href = url;
    //}
    Swal.fire({
        title: 'Delete user',
        text: "Are you sure to delete your account, this will also delete all your folders.",
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
            window.location.href = url;
        }
    });
}