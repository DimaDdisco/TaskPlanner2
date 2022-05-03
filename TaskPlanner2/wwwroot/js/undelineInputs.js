
let toggleActive = (event) => event.target.parentNode.classList.toggle("active");

document.querySelectorAll(".text-input").forEach(input => {
    input.addEventListener("focusin", toggleActive);
    input.addEventListener("focusout", toggleActive);
});