const deleteFolderId = document.getElementById("deleteFolderId");
const viewFolderId = document.getElementById("viewdFolderId");
const updateFolderId = document.getElementById("updateFolderId");
document.querySelectorAll('.folder-item').forEach(folderItem => {

    folderItem.addEventListener('mouseenter', () => {
        deleteFolderId.value = folderItem.id;
        viewFolderId.value = folderItem.id;
        updateFolderId.value = folderItem.id;
    });
});