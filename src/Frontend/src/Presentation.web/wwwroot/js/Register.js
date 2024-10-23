const password = document.getElementById("password");
const confirmPassword = document.getElementById("confirmPassword");
const confirmPasswordMessage = document.getElementById("confirmPasswordMessage");
const submitBtn = document.getElementById("submitButton");

function updateInputClasses(element, addClass, removeClass) {
    element.classList.add(addClass);
    element.classList.remove(removeClass);
}

password.addEventListener("input", () => {

    if (password.value != confirmPassword.value) {
        updateInputClasses(confirmPassword, "input-error", "input-text");
        updateInputClasses(confirmPassword, "input-error", "input-correct");
        confirmPasswordMessage.textContent = "Passwords do not match!";
    } else {
        updateInputClasses(confirmPassword, "input-correct", "input-text");
        updateInputClasses(confirmPassword, "input-correct", "input-error");
    }

    if (password.value == "") {
        confirmPassword.value = "";
        updateInputClasses(confirmPassword, "input-text", "input-error");
        updateInputClasses(confirmPassword, "input-text", "input-correct");
        confirmPasswordMessage.textContent = "";
    }

    if (password.value.length > 1 || password.value.length < 8) {
        updateInputClasses(password, "input-error", "input-text");
    }else if (password.value.length >= 8) {
        updateInputClasses(password, "input-correct", "input-text");
    } else {
        updateInputClasses(password, "input-text", "input-correct");
        updateInputClasses(password, "input-text", "input-error");
    }
});

// Muestra en la consola cada vez que el usuario escribe en el campo confirmPassword
confirmPassword.addEventListener("input", () => {
    console.log(`Confirm Password input changed: ${password.value} ${confirmPassword.value}`);
    if (confirmPassword.value == "") {
        updateInputClasses(confirmPassword, "input-text", "input-error");
        updateInputClasses(confirmPassword, "input-text", "input-correct");
        confirmPasswordMessage.textContent = "";
    } else if (password.value == confirmPassword.value) {
        updateInputClasses(confirmPassword, "input-correct", "input-text");
        confirmPasswordMessage.textContent = "";
    } else {
        updateInputClasses(confirmPassword, "input-error", "input-text");
        updateInputClasses(confirmPassword, "input-error", "input-correct");
        confirmPasswordMessage.textContent = "Passwords do not match!";
    }

    if (password.value.length > 0 && password.value == confirmPassword.value) {
        submitBtn.disabled = false;
    }
});
