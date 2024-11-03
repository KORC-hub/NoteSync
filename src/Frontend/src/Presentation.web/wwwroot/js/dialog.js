const dialog = document.getElementById("myDialog");
const openBtn = document.getElementById("openModalBtn");
const closeBtn = document.getElementById("closeDialogBtn");
const searchTag = document.getElementById("tagName");
const tagsContainer = document.getElementById("tagsContainer");

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

document.getElementById("addTagBtn").addEventListener("click", function () {
    var tagText = document.getElementById("tagName").value;
    var tagColor = document.getElementById("tagColor").value;
    if (tagText != "") {
        var newTag = document.createElement("div");
        newTag.classList.add("tag");
        newTag.id = "new";
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
    selectMenu.classList.add("menu-open");
    if (searchTag.value == "" || selectMenu.innerHTML.trim() === "") {
        selectMenu.classList.remove("menu-open");
    } else {
        // Mostrar las sugerencias que coinciden
        options.forEach((option) => {
            option.addEventListener(
                "click",
                () => {
                    const tagDiv = option.querySelector(".tag");
                    if (tagDiv) {
                        tagDiv.addEventListener(
                            "click",
                            () => {
                                const li = document.createElement("li");
                                const tagColor = getComputedStyle(tagDiv).getPropertyValue("--tag-color");
                                const tagnName = tagDiv.textContent;
                                li.innerHTML = `<div class="tag" id="${tagDiv.id}" class="tag" style="--tag-color: ${tagColor}">${tagnName}</div>`;
                                selectMenu.appendChild(li);
                                tagDiv.remove();
                            },
                            { once: true }
                        );

                        tagsContainer.appendChild(tagDiv);
                        option.remove();
                        selectMenu.classList.remove("menu-open");
                    }
                },
                { once: true }
            );
        });
    }
});

searchTag.addEventListener("focusout", () => {
    const selectMenu = document.querySelector(".select-menu");
    selectMenu.classList.remove("menu-open");
});

document.getElementById("createFolderForm").addEventListener("submit", function (event) {
    const tags = document.querySelectorAll("#tagsContainer .tag");
    const tagListInput = document.getElementById("tagList");
    let TagList = [];

    tags.forEach((tag) => {
        if (tag.id == "new") {
            TagList.push({
                Type: "new",
                TagContent: tag.textContent,
                Color: getComputedStyle(tag).getPropertyValue("--tag-color")
            });
        } else {
            TagList.push({
                Type: "existing",
                TagId: tag.id
            });
        }
    });

    tagListInput.value = JSON.stringify(TagList);
});
