import * as input from '../BasicScript/inputValidation.js';

const UpdateFolderForm = document.getElementById("updateFolderForm");
const updateFolderSearchTag = document.getElementById("updateTagName");
const updateFolderTagsContainer = document.getElementById("tagsContainer");
const updateFolderTagsAddTagBtn = document.getElementById("updateFolderAddTagBtn");


let FolderName = document.getElementById("UpdateFolderName");
const FolderNameMessage = document.getElementById("fileNameMessage");
const saveBtn = document.getElementById("updateFoldersaveBtn");

FolderName.addEventListener("input", () => {
    saveBtn.disabled = true;
    let ErrorMessage = input.ValidationByRange(FolderName, 5, 50);
    FolderNameMessage.textContent = (ErrorMessage == "") ? "" : "Folder name " + ErrorMessage;

    if (FolderName.value == "") {
        saveBtn.disabled = true;
        input.reset(FolderName);
        FolderNameMessage.textContent = "";
    } else {
        if (!FolderNameMessage.textContent) {
            saveBtn.disabled = false;
        }
    }
});



updateFolderTagsAddTagBtn.addEventListener("click", function () {
    var tagText = document.getElementById("updateTagName").value;
    var tagColor = document.getElementById("updateFolderTagColor").value;
    if (tagText != "") {
        var newTag = document.createElement("div");
        newTag.classList.add("tag");
        newTag.id = "new";
        newTag.style.setProperty("--tag-color", tagColor);
        newTag.textContent = tagText;

        newTag.addEventListener("click", function () {
            newTag.remove();
        });
        document.getElementById("updateTagsContainer").appendChild(newTag);
        document.querySelector(".select-menu").classList.remove("menu-open");
    }
});

updateFolderSearchTag.addEventListener("input", function () {
    const selectMenu = document.getElementById("updateFolderSelectMenu");
    const options = document.querySelectorAll("#updateFolderSelectMenu li");
    const tagsContainer = document.getElementById("updateTagsContainer");
    selectMenu.classList.add("menu-open");
    if (updateFolderSearchTag.value == "" || selectMenu.innerHTML.trim() === "") {
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

updateFolderSearchTag.addEventListener("focusout", () => {
    const selectMenu = document.getElementById("updateFolderSelectMenu");
    selectMenu.classList.remove("menu-open");
});

UpdateFolderForm.addEventListener("submit", function (event) {
    const tagsContainer = document.getElementById("updateTagsContainer");
    const tags = tagsContainer.querySelectorAll("#updateTagsContainer .tag");
    const tagListInput = document.getElementById("updateTagList");
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



const updateFolderDialog = document.getElementById("updateFolderDialog");
const updateFolderOpenBtn = document.getElementById("updateFolderOpenDialogBtn");
const updateFolderCancelBtn = document.getElementById("updateFolderCancelBtn");
function resetDialog()
{
    const tagsContainer = document.getElementById("updateTagsContainer");
    const selectMenu = document.getElementById("updateFolderSelectMenu");
    const existingTags = tagsContainer.querySelectorAll("#updateTagsContainer .tag");
    existingTags.forEach(tagDiv => {
        if (tagDiv > 0) {
            const li = document.createElement("li");
            const tagColor = getComputedStyle(tagDiv).getPropertyValue("--tag-color");
            const tagName = tagDiv.textContent;
            li.innerHTML = `<div id="${tagDiv.id}" class="tag" style="--tag-color: ${tagColor}">${tagName}</div>`;
            selectMenu.appendChild(li);
            tagDiv.remove();
        }
    });
    FolderName.value = "";
    updateFolderSearchTag.value = "";
    UpdateFolderForm.querySelector(".tags").innerHTML = "";
}

document.querySelectorAll('.folder-item').forEach(folderItem => {
    
    folderItem.querySelector('.updateFolderOpenDialogBtn').addEventListener('click', () => {
        const selectMenu = document.getElementById("updateFolderSelectMenu");
        const updateFolderName = folderItem.querySelector('.name').textContent;
        document.getElementById("UpdateFolderName").value = updateFolderName;
        let tags = folderItem.querySelector(".tags").cloneNode(true);

        tags.querySelectorAll(".tag").forEach(tag => {
            const options = document.querySelectorAll("#updateFolderSelectMenu li");
            options.forEach((option) => {
                const existingTag = option.querySelector(".tag");
                if (existingTag.id == tag.id) {
/*                    temporalyRemoveTags.appendChild(op)*/
                    option.remove();
                }
            });
            
            UpdateFolderForm.querySelector(".tags").appendChild(tag);
            tag.addEventListener(
                "click",
                () => {

                    const li = document.createElement("li");
                    const tagColor = getComputedStyle(tag).getPropertyValue("--tag-color");
                    const tagName = tag.textContent;
                    li.innerHTML = `<div class="tag" style="--tag-color: ${tagColor}">${tagName}</div>`;
                    selectMenu.appendChild(li);
                    tag.remove();
                },
                { once: true }
            );
        });

        updateFolderDialog.showModal();
    });
});

updateFolderDialog.addEventListener("click", (event) => {
    if (event.target === updateFolderDialog) {
        resetDialog();
        updateFolderDialog.close();
    }
});

updateFolderCancelBtn.addEventListener("click", () => {
    resetDialog();
    /*ValidatFoldeName();*/
    updateFolderDialog.close();
});