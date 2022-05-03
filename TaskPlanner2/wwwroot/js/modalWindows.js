
let modalOverlay = document.getElementById("modal-overlay");
let modals = document.querySelectorAll("modal");

let currentModal;

let getModal = (target) => {
    let path = target.getAttribute("modal-path");
    let modal = document.querySelector(`[data-target="${path}"]`);
    return modal;
}

let clearModal = (modal) => {
    modal.querySelectorAll(".text-input")?.forEach((input) => {
        input.value = "";
    })
}

let getData = (target) => {
    let path = target.getAttribute("data-path");
    let data = document.querySelector(`[data-target="${path}"]`);
    return data;
}

// OPEN
let openModals = (modal) => {
    modalOverlay?.classList.add("show");
    modal?.classList.add("show");
    currentModal = modal;
}

// ADD TASK
let addTask = document.querySelectorAll(".modal-AddTask");
addTask.forEach((button) => {
    button.addEventListener("click", (e) => {
        let modal = getModal(e.currentTarget);
        clearModal(modal);
        openModals(modal);
    });
});

// CHANGE TASK 
let changeTask = document.querySelectorAll(".modal-ChangeTask");
changeTask.forEach((button) => {
    button.addEventListener("click", (e) => {
        let modal = getModal(e.currentTarget);
        clearModal(modal);
        openModals(modal);

        let data = getData(e.currentTarget);
        modal.querySelector("#Title").value = data.querySelector(".title").innerText;
        modal.querySelector("#Description").value = data.querySelector(".description").innerText;
        modal.querySelectorAll(".id").forEach((TaskId) => {
            TaskId.value = data.querySelector(".id").innerText;
        });
    });
});

// ADD SUBTASK
let addSubTask = document.querySelectorAll(".modal-AddSubTask");
addSubTask.forEach((button) => {
    button.addEventListener("click", (e) => {
        let modal = getModal(e.currentTarget);
        clearModal(modal);
        openModals(modal);

        let id = getData(e.currentTarget).querySelector(".id").innerText;
        modal.querySelector("#TaskId").value = id;
    });
});

// CLOSE
let closeModals = () => {
    modalOverlay?.classList.remove("show");
    currentModal?.classList.remove("show");
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