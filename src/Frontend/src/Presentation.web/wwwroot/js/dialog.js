const dialog = document.getElementById("myDialog");
const openBtn = document.getElementById("openModalBtn");
const closeBtn = document.getElementById("closeDialogBtn");

// Abre el diálogo
openBtn.addEventListener("click", () => {
    console.log("a");
    dialog.showModal(); // Muestra el diálogo como modal
});

// Cierra el diálogo al hacer clic en el botón de cerrar
closeBtn.addEventListener("click", () => {
    dialog.close(); // Cierra el diálogo
});

// Cierra el diálogo al hacer clic fuera del área del diálogo
dialog.addEventListener("click", (event) => {
    if (event.target === dialog) {
        dialog.close();
    }
});
