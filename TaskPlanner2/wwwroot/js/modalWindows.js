
let modalButtons = document.querySelectorAll(".modalButton");
let modalOverlay = document.getElementById("modal-overlay");
let modals = document.querySelectorAll("modal");

let currentModal;

modalButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
        let data = e.currentTarget.getAttribute("data-path");
        modalOverlay.classList.add("show");
        let modal = document.querySelector(`[data-target="${data}"]`);
        modal.classList.add("show");
        currentModal = modal;
    });
});

let closeModals = () => {
    modalOverlay.classList.remove("show");
    if (currentModal) {
        currentModal.classList.remove("show");
    }
}

document.addEventListener("keydown", (e) => {
    if (e.key === "Escape") {
        e.preventDefault();
        closeModals();
    }
});

modalOverlay.addEventListener("click", (e) => {
    if (e.target === modalOverlay) {
        closeModals();
    }
});