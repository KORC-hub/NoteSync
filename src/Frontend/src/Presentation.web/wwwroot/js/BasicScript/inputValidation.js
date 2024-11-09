function updateInputClasses(element, addClass, removeClass) {
    element.classList.add(addClass);
    element.classList.remove(removeClass);
}

export function reset(input)
{
    updateInputClasses(input, "input-text", "input-error");
    updateInputClasses(input, "input-text", "input-correct");
}

export function ValidationByMinimum(input, min) {

    let ErrorMessage;

    if (input.value.length < min) {
        updateInputClasses(input, "input-error", "input-text");
        updateInputClasses(input, "input-error", "input-correct");
        ErrorMessage = "must be at least "+min+" characters long";
    } else {
        updateInputClasses(input, "input-correct", "input-text");
        updateInputClasses(input, "input-correct", "input-error");
        ErrorMessage = "";
    }

    return ErrorMessage;
}


export function ValidationByRange(input, min, max) {

    let ErrorMessage;

    if (input.value.length < min || input.value.length > max) {
        updateInputClasses(input, "input-error", "input-text");
        updateInputClasses(input, "input-error", "input-correct");
        ErrorMessage = "must be a minimum of " + min + " characters and maximum of " + max + " characters";
    } else {
        updateInputClasses(input, "input-correct", "input-text");
        updateInputClasses(input, "input-correct", "input-error");
        ErrorMessage = "";
    }
    
    return ErrorMessage;
}

export function ValidationByEqualFields(input1, input2) {

    let ErrorMessage;

    if (input1.value != input2.value) {
        updateInputClasses(input2, "input-error", "input-text");
        updateInputClasses(input2, "input-error", "input-correct");
        ErrorMessage = " do not match!";
    } else {
        updateInputClasses(input2, "input-correct", "input-text");
        updateInputClasses(input2, "input-correct", "input-error");
        ErrorMessage = "";
    }
    return ErrorMessage;
}