const dialog = document.getElementById("myDialog");
const openBtn = document.getElementById("openModalBtn");
const closeBtn = document.getElementById("closeDialogBtn");
const searchTag = document.getElementById("tagName");
const savetBtn = document.getElementById("saveBtn");
const CancelBtn = document.getElementById("CancelBtn");

// Abre el diálogo
openBtn.addEventListener("click", () => {
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


const FolderName = document.getElementById("folderName");
const FolderNameMessage = document.getElementById("folderNameMessage");

function updateInputClasses(element, addClass, removeClass) {
    element.classList.add(addClass);
    element.classList.remove(removeClass);
}
function ValidatFoldeName() {
    if (FolderName.value.length < 5 || FolderName.value.length > 50) {
        savetBtn.disabled = true;
        updateInputClasses(FolderName, "input-error", "input-text");
        updateInputClasses(FolderName, "input-error", "input-correct");
        FolderNameMessage.textContent = "Folder name must be greater than 5 and less than 50";
    } else {
        savetBtn.disabled = false;
        updateInputClasses(FolderName, "input-correct", "input-text");
        updateInputClasses(FolderName, "input-correct", "input-error");
        FolderNameMessage.textContent = "";
    }
    if (FolderName.value == "")
    {
        savetBtn.disabled = true;
        updateInputClasses(FolderName, "input-text", "input-error");
        updateInputClasses(FolderName, "input-text", "input-correct");
        FolderNameMessage.textContent = "";
    }

}

FolderName.addEventListener("input", () => {
    ValidatFoldeName();
});

CancelBtn.addEventListener("click", () => {
    FolderName.value = "";
    searchTag.value = "";
    const tagsContainer = document.getElementById("tagsContainer");
    const selectMenu = document.querySelector(".select-menu");
    const existingTags = tagsContainer.querySelectorAll(".tag");
    existingTags.forEach(tagDiv => {
        const li = document.createElement("li");
        const tagColor = getComputedStyle(tagDiv).getPropertyValue("--tag-color");
        const tagName = tagDiv.textContent;
        li.innerHTML = `<div class="tag" style="--tag-color: ${tagColor}">${tagName}</div>`;
        selectMenu.appendChild(li);
        tagDiv.remove();
    });
    ValidatFoldeName();
    dialog.close();
});

document.getElementById("addTagBtn").addEventListener("click", function () {
    var tagText = document.getElementById("tagName").value;
    var tagColor = document.getElementById("tagColor").value;
    if (tagText != "") {
        var newTag = document.createElement("div");
        newTag.classList.add("tag");
        newTag.style.setProperty("--tag-color", tagColor);
        newTag.textContent = tagText;

        newTag.addEventListener("click", function () {
            newTag.remove();
        });

        document.getElementById("tagsContainer").appendChild(newTag);
        document.querySelector(".select-menu").classList.remove("menu-open");
    }
});

searchTag.addEventListener("input", function () {
    const selectMenu = document.querySelector(".select-menu");
    const options = document.querySelectorAll(".select-menu li");
    const tagsContainer = document.getElementById("tagsContainer");
    let tags = [];
    selectMenu.classList.add("menu-open");
    if (searchTag.value == "" || selectMenu.innerHTML.trim() === "") {
        selectMenu.classList.remove("menu-open");
    }

    // Mostrar las sugerencias que coinciden
    options.forEach((option) => {
        option.addEventListener("click", () => {
            const tagDiv = option.querySelector(".tag");

            tagDiv.addEventListener("click", function () {
                const li = document.createElement("li");
                const tagColor = getComputedStyle(tagDiv).getPropertyValue("--tag-color");
                const tagnName = tagDiv.textContent;
                li.innerHTML = `<div class="tag" style="--tag-color: ${tagColor}">${tagnName}</div>`;
                selectMenu.appendChild(li);
                tagDiv.remove();
            });

            tagsContainer.appendChild(tagDiv);
            option.remove();
            selectMenu.classList.remove("menu-open");
        });
    });
});

searchTag.addEventListener("blur", () => {
    const selectMenu = document.querySelector(".select-menu");
    selectMenu.classList.remove("menu-open");
});
