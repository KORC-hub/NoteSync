import * as input from '../BasicScript/inputValidation.js';


// Nickname
const nickname = document.getElementById("nickname");
const nickNameMessage = document.getElementById("nicknameMessage");

// Password
const password = document.getElementById("password");
const passwordMessage = document.getElementById("passwordMessage");

//Confirm Password
const confirmPassword = document.getElementById("confirmPassword");
const confirmPasswordMessage = document.getElementById("confirmPasswordMessage");

//Email
const emailMessage = document.getElementById("emailMessage");

const submitBtn = document.getElementById("submitButton"); // submit button

function ValidatePassword() {
    submitBtn.disabled = true;
    let ErrorMessage = input.ValidationByMinimum(password, 10)
    passwordMessage.textContent = (ErrorMessage == "") ? "" : "The password " + ErrorMessage;

    if (!password.value) {
        submitBtn.disabled = true;
        input.reset(password);
        passwordMessage.textContent = "";
    }

    ErrorMessage = input.ValidationByEqualFields(password, confirmPassword);
    confirmPasswordMessage.textContent = (ErrorMessage == "") ? "" : ErrorMessage;
    if (!(passwordMessage.textContent || confirmPasswordMessage.textContent)) {
        submitBtn.disabled = false;
    }
}


function resetPasswordinputs() {
    if (confirmPassword.value == "") {
        ValidatePassword();
    }
    if (password.value == "") {
        input.reset(password);
        input.reset(confirmPassword)
        passwordMessage.textContent = "";
        confirmPassword.value = "";
        confirmPasswordMessage.textContent = "";
    }
}

nickname.addEventListener("input", () => {
    submitBtn.disabled = true;
    let ErrorMessage = input.ValidationByRange(nickname, 5, 15)
    nickNameMessage.textContent = (ErrorMessage == "") ? "" : "The user name " + ErrorMessage;  

    if (nickname.value == "") {
        input.reset(nickname);
        nickNameMessage.textContent = "";
    } else if (nickNameMessage.textContent == "") {
        submitBtn.disabled = false;
    }

    if (!(password.value || confirmPassword.value)) {
        submitBtn.disabled = false;
    }

});

password.addEventListener("input", () => {
    ValidatePassword();
    resetPasswordinputs();
});

confirmPassword.addEventListener("input", () => {
    ValidatePassword();
    resetPasswordinputs();
});
