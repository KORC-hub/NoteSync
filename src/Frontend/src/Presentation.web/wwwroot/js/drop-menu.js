function toggleMenu(button) {
    var menu = button.nextElementSibling; // Selecciona el menú correspondiente al botón clicado
    var allMenus = document.querySelectorAll(".drop-menu");

    // Oculta todos los menús antes de abrir el que se clicó
    allMenus.forEach(function (m) {
        if (m !== menu) {
            m.style.display = "none";
        }
    });

    // Alterna el menú correspondiente
    if (menu.style.display === "block") {
        menu.style.display = "none";
    } else {
        menu.style.display = "block";
    }
}

// Cerrar el menú si se hace clic fuera
window.onclick = function (event) {
    if (!event.target.matches(".drop-menu-btn")) {
        var menus = document.querySelectorAll(".drop-menu");
        menus.forEach(function (menu) {
            if (menu.style.display === "block") {
                menu.style.display = "none";
            }
        });
    }
};