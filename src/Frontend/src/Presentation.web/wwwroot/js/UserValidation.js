const password = document.getElementById("password");
const nickname = document.getElementById("nickname");
const confirmPassword = document.getElementById("confirmPassword");
const passwordMessage = document.getElementById("passwordMessage");
const confirmPasswordMessage = document.getElementById("confirmPasswordMessage");
const nickNameMessage = document.getElementById("nicknameMessage");
const emailMessage = document.getElementById("emailMessage");
const submitBtn = document.getElementById("submitButton");

function updateInputClasses(element, addClass, removeClass) {
    element.classList.add(addClass);
    element.classList.remove(removeClass);
}

function ValidateNickname() {
    if (nickname.value.length < 5 || nickname.value.length > 15) {
        submitBtn.disabled = true;
        updateInputClasses(nickname, "input-error", "input-text");
        updateInputClasses(nickname, "input-error", "input-correct");
        nickNameMessage.textContent = "the user name must be a minimum of 5 characters and maximum of 15 characters";
    } else {
        submitBtn.disabled = false;
        updateInputClasses(nickname, "input-correct", "input-text");
        updateInputClasses(nickname, "input-correct", "input-error");
        nickNameMessage.textContent = "";
    }
}

function ValidatePassword() {
    if (password.value.length >= 1 && password.value.length < 10) {
        updateInputClasses(password, "input-error", "input-text");
        updateInputClasses(password, "input-error", "input-correct");
        passwordMessage.textContent = "the password must be at least 10 characters long";
    } else {
        updateInputClasses(password, "input-correct", "input-text");
        updateInputClasses(password, "input-correct", "input-error");
        passwordMessage.textContent = "";
    }
}

function ValidateConfirmPassword() {
    if (password.value != confirmPassword.value) {
        submitBtn.disabled = true;
        updateInputClasses(confirmPassword, "input-error", "input-text");
        updateInputClasses(confirmPassword, "input-error", "input-correct");
        confirmPasswordMessage.textContent = "Passwords do not match!";
    } else {
        updateInputClasses(confirmPassword, "input-correct", "input-text");
        updateInputClasses(confirmPassword, "input-correct", "input-error");
        confirmPasswordMessage.textContent = "";
        if (!passwordMessage.textContent) {
            submitBtn.disabled = false;
        }
    }
}

function resetNickname() {
    if (nickname.value == "") {
        updateInputClasses(nickname, "input-text", "input-error");
        updateInputClasses(nickname, "input-text", "input-correct");
        nickNameMessage.textContent = "";
    }
}

function resetPasswordinputs() {
    if (confirmPassword.value == "") {
        ValidateConfirmPassword();
    }
    if (password.value == "") {
        updateInputClasses(password, "input-text", "input-error");
        updateInputClasses(password, "input-text", "input-correct");
        updateInputClasses(confirmPassword, "input-text", "input-error");
        updateInputClasses(confirmPassword, "input-text", "input-correct");
        passwordMessage.textContent = "";
        confirmPassword.value = "";
        confirmPasswordMessage.textContent = "";
    }
}

password.addEventListener("input", () => {
    ValidatePassword();
    ValidateConfirmPassword();
    resetPasswordinputs();
});

// Muestra en la consola cada vez que el usuario escribe en el campo confirmPassword
confirmPassword.addEventListener("input", () => {
    ValidatePassword();
    ValidateConfirmPassword();
    resetPasswordinputs();
});

nickname.addEventListener("input", () => {
    console.log("hello");
    ValidateNickname();
    resetNickname();
});
