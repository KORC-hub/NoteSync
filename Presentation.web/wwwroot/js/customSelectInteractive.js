const customSelects = document.querySelectorAll(".custom-select");

customSelects.forEach((customSelect) => {
    console.log("Pass");
    const select = customSelect.querySelector(".select");
    const caret = customSelect.querySelector(".caret");
    const selectMenu = customSelect.querySelector(".select-menu");
    const options = customSelect.querySelectorAll(".select-menu li");
    const selected = customSelect.querySelector(".selected");

    select.addEventListener("click", () => {
        select.classList.toggle("select-clicked");
        caret.classList.toggle("caret-rotate");
        selectMenu.classList.toggle("menu-open");
    });

    options.forEach((option) => {
        option.addEventListener("click", () => {
            const tagDiv = option.querySelector(".tag");

            if (tagDiv) {
                selected.innerHTML = tagDiv.outerHTML;
            } else {
                selected.innerText = option.innerText;
            }
            select.classList.remove("select-clicked");
            caret.classList.remove("caret-rotate");
            selectMenu.classList.remove("menu-open");
            options.forEach((option) => {
                option.classList.remove("active");
            });
            option.classList.add("active");
        });
    });

    window.addEventListener("click", (e) => {
        const size = customSelect.getBoundingClientRect();
        if (e.clientX < size.left || e.clientX > size.right || e.clientY < size.top || e.clientY > size.bottom) {
            select.classList.remove("select-clicked");
            caret.classList.remove("caret-rotate");
            selectMenu.classList.remove("menu-open");
        }
    });
});
