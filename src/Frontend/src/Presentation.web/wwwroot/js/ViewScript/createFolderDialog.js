import * as input from '../BasicScript/inputValidation.js';

const CreateFolderForm = document.getElementById("createFolderForm");
const searchTag = document.getElementById("tagName");
const tagsContainer = document.getElementById("tagsContainer");
const addTagBtn = document.getElementById("addTagBtn");

let FolderName = document.getElementById("name");
const FolderNameMessage = document.getElementById("folderNameMessage");
const saveBtn = document.getElementById("saveBtn");

FolderName.addEventListener("input", () => {
    saveBtn.disabled = true;
    let ErrorMessage = input.ValidationByRange(FolderName, 5, 50);
    FolderNameMessage.textContent = (ErrorMessage == "") ? "" : "Folder name " + ErrorMessage; 

    if (FolderName.value == "") {
        saveBtn.disabled = true;
        input.reset(FolderName);
        FolderNameMessage.textContent = "";
    } else
    {
        if (!FolderNameMessage.textContent)
        {
            saveBtn.disabled = false;
        }
    }
});

addTagBtn.addEventListener("click", function () {
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

CreateFolderForm.addEventListener("submit", function (event) {
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

const createFodlerDialog = document.getElementById("createFolderDialog");
const createFolderOpenBtn = document.getElementById("createFolderOpenDialogBtn");
const createFolderCancelBtn = document.getElementById("createFolderCancelBtn");

createFolderOpenBtn.addEventListener("click", () => {
    createFodlerDialog.showModal();
});

createFodlerDialog.addEventListener("click", (event) => {
    if (event.target === createFodlerDialog) {
        createFodlerDialog.close();
    }
});

createFolderCancelBtn.addEventListener("click", () => {
    document.getElementById("name").value = "";
    searchTag.value = "";
    const tagsContainer = document.getElementById("tagsContainer");
    const selectMenu = document.querySelector(".select-menu");
    const existingTags = tagsContainer.querySelectorAll(".tag");
    existingTags.forEach(tagDiv => {
        if (tagDiv > 0) {
            const li = document.createElement("li");
            const tagColor = getComputedStyle(tagDiv).getPropertyValue("--tag-color");
            const tagName = tagDiv.textContent;
            li.innerHTML = `<div class="tag" style="--tag-color: ${tagColor}">${tagName}</div>`;
            selectMenu.appendChild(li);
            tagDiv.remove();
        }
    });
    tagsContainer.innerHTML = "";
    /*ValidatFoldeName();*/
    createFodlerDialog.close();
});