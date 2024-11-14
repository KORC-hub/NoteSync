import * as input from '../BasicScript/inputValidation.js';
let isSignInGlobal = true;
document.addEventListener('DOMContentLoaded', function () {
    const toggleLink = document.getElementById('toggle-link');
    const formTitle = document.getElementById('form-title');
    const extraFields = document.getElementsByClassName('extra-input');
    const submitButton = document.querySelector('.button');
    const toggleText = document.getElementById('toggle-text');

    let isSignIn = true;

    function toggleForm() {
        if (isSignIn) {
            formTitle.textContent = 'Sign Up';
            submitButton.textContent = 'Sign Up';
            submitButton.setAttribute("form", "signUp");
            // Añade la clase 'slide-down' para mostrar los campos con animación
            for (let field of extraFields) {
                field.classList.add('slide-down');
            }
            toggleText.innerHTML = 'Already have an account? <a href="#" id="toggle-link">Sign in</a>';

        } else {
            formTitle.textContent = 'Sign In';
            submitButton.textContent = 'Sign In';
            submitButton.setAttribute("form", "signIn");
            // Remueve la clase 'slide-down' para ocultar los campos con animación
            for (let field of extraFields) {
                field.classList.remove('slide-down');
            }
            toggleText.innerHTML = 'Don\'t have an account yet? <a href="#" id="toggle-link">Sign up</a>';
        }
        isSignIn = !isSignIn;
        isSignInGlobal = isSignIn
        setToggleLinkListener();

    }

    function setToggleLinkListener() {
        const newToggleLink = document.getElementById('toggle-link');
        newToggleLink.addEventListener('click', (e) => {
            e.preventDefault();
            toggleForm();
        });
    }

    setToggleLinkListener();

    const name = document.getElementById('AccessNickName');
    const email = document.getElementById('AccessEmail');
    const password = document.getElementById('AccessPassword');

    const loginEmail = document.getElementById('loginEmail');
    const loginPassword = document.getElementById('loginPassword');

    const registerNickName = document.getElementById('registerNickName');
    const registerEmail = document.getElementById('registerEmail');
    const registerPassword = document.getElementById('registerPassword');

    name.addEventListener("input", function () {
        registerNickName.value = name.value;
    });

    email.addEventListener("input", function () {
        loginEmail.value = email.value;
        registerEmail.value = email.value;
    });

    password.addEventListener("input", function () {
        loginPassword.value = password.value;
        registerPassword.value = password.value;
    });

});

// Nickname
const nickname = document.getElementById("AccessNickName");
const nickNameMessage = document.getElementById("nicknameMessage");

// Email
const email = document.getElementById("AccessEmail");
const emailMessage = document.getElementById("emailMessage");

// Password
const password = document.getElementById("AccessPassword");
const passwordMessage = document.getElementById("passwordMessage");

//Confirm Password
const confirmPassword = document.getElementById("AccessConfirmPassword");
const confirmPasswordMessage = document.getElementById("confirmPasswordMessage");

const submitBtn = document.getElementById("submitBtn"); // submit button

function ValidatePassword() {
    submitBtn.disabled = true;
    let ErrorMessage = input.ValidationByMinimum(password, 10);
    passwordMessage.textContent = ErrorMessage == "" ? "" : "The password " + ErrorMessage;

    if (!password.value) {
        submitBtn.disabled = true;
        input.reset(password);
        passwordMessage.textContent = "";
    }

    ErrorMessage = input.ValidationByEqualFields(password, confirmPassword);
    confirmPasswordMessage.textContent = ErrorMessage == "" ? "" : ErrorMessage;
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
        input.reset(confirmPassword);
        passwordMessage.textContent = "";
        confirmPassword.value = "";
        confirmPasswordMessage.textContent = "";
    }
}

nickname.addEventListener("input", () => {
    submitBtn.disabled = true;
    if (!(password.value || confirmPassword.value) && (nickname.value> 5)) {
        submitBtn.disabled = false;
    }
});

email.addEventListener("input", () => {
    submitBtn.disabled = true;
    if (!isSignInGlobal)
    {
        let ErrorMessage = input.EmailValidation(email)
        emailMessage.textContent = ErrorMessage == "" ? "" : ErrorMessage;

        if (!(password.value || confirmPassword.value) && emailMessage == "") {
            submitBtn.disabled = false;
        }
    }

    if (email.value == "") {
        input.reset(email)
        emailMessage.textContent = "";
    }

    if (email.value != "" && (password.value != ""))
    {
        submitBtn.disabled = false;
    }
});


password.addEventListener("input", () => {
    submitBtn.disabled = true;
    if (!isSignInGlobal)
    {
        ValidatePassword();
        resetPasswordinputs();
    }
    if (password.value != "" && email.value != "" && passwordMessage.textContent == "" && confirmPasswordMessage.textContent == "") {
        submitBtn.disabled = false;
    }
    if (password.value == "")
    {
        submitBtn.disabled = true;
    }

});

confirmPassword.addEventListener("input", () => {
    ValidatePassword();
    resetPasswordinputs();
});

const showPasswordButton = document.getElementById("showPassword");
const showConfirmPasswordButton = document.getElementById("showConfirmPassword");

showPasswordButton.addEventListener("click", function (event) {
    const showSVG = document.querySelector("#showPassword .icon-tabler-eye");
    const hiddenSVG = document.querySelector("#showPassword .icon-tabler-eye-off");
    showSVG.classList.toggle("hidden-svg");
    hiddenSVG.classList.toggle("hidden-svg");
    if (password.type === "password") {
        password.type = "text";
    } else {
        password.type = "password";
    }
});

showConfirmPasswordButton.addEventListener("click", function (event) {
    const inputPasswordConfirm = document.getElementById("confirmPassword");
    const showSVG = document.querySelector("#showConfirmPassword .icon");
    const hiddenSVG = document.querySelector("#showConfirmPassword .icon-tabler-eye-off");
    showSVG.classList.toggle("hidden-svg");
    hiddenSVG.classList.toggle("hidden-svg");
    if (confirmPassword.type === "password") {
        confirmPassword.type = "text";
    } else {
        confirmPassword.type = "password";
    }
});

