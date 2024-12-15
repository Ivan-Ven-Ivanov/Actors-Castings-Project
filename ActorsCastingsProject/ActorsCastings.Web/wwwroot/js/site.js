function toggleSelection(card) {
    const selectedCard = document.querySelector(".clickable-card.selected");
    const addButton = document.getElementById("add-selected-button");

    if (selectedCard && selectedCard !== card) {
        selectedCard.classList.remove("selected");

        const hiddenInput = selectedCard.querySelector("input[type='hidden']");
        const roleInputDiv = selectedCard.querySelector(".role-input");
        const roleInput = roleInputDiv.querySelector("input");

        roleInputDiv.classList.add("d-none");
        hiddenInput.disabled = true;
        roleInput.disabled = true;

        roleInput.value = "";
        roleInput.dispatchEvent(new Event("input")); 
    }

    const hiddenInput = card.querySelector("input[type='hidden']");
    const roleInputDiv = card.querySelector(".role-input");
    const roleInput = roleInputDiv.querySelector("input");

    if (card.classList.contains("selected")) {
        card.classList.remove("selected");
        hiddenInput.disabled = true;
        roleInput.disabled = true;
        roleInputDiv.classList.add("d-none");
    } else {
        card.classList.add("selected");
        hiddenInput.disabled = false;
        roleInput.disabled = false;
        roleInputDiv.classList.remove("d-none");
    }

    const anySelected = document.querySelectorAll(".clickable-card.selected").length > 0;
    addButton.disabled = !anySelected;

    if (card.classList.contains("selected")) {
        roleInput.dispatchEvent(new Event("input")); 
    }
}


document.querySelectorAll('.role-input input').forEach(input => {
    input.addEventListener('click', function (e) {
        e.stopPropagation();
    });
});

document.addEventListener('DOMContentLoaded', function () {
    flatpickr('.datetime-picker', {
        enableTime: true, 
        dateFormat: "d/m/Y H:i", 
        time_24hr: true 
    });
});


window.onload = function () {
    const checkboxes = document.querySelectorAll("input[type='checkbox'][name='SelectedMovies']");
    let selectedCheckbox = null;

    checkboxes.forEach((checkbox) => {
        if (checkbox.checked) {
            selectedCheckbox = checkbox;
        }
    });

    if (selectedCheckbox) {
        handleSelection(selectedCheckbox);
    }
};

window.onload = function () {
    const selectedCard = document.querySelector(".clickable-card.selected");
    if (selectedCard) {
        const roleInputDiv = selectedCard.querySelector(".role-input");
        const roleInput = roleInputDiv.querySelector("input");
        const hiddenInput = selectedCard.querySelector("input[type='hidden']");
        const addButton = document.getElementById("add-selected-button");

        roleInput.disabled = false;
        hiddenInput.disabled = false;
        roleInputDiv.classList.remove("d-none");
        addButton.disabled = false;
    }
};
