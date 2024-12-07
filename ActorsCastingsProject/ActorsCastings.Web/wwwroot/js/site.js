function toggleSelection(card) {
    const selectedCard = document.querySelector(".clickable-card.selected");
    const addButton = document.getElementById("add-selected-button");

    // Deselect the previously selected card
    if (selectedCard && selectedCard !== card) {
        selectedCard.classList.remove("selected");

        const hiddenInput = selectedCard.querySelector("input[type='hidden']");
        const roleInputDiv = selectedCard.querySelector(".role-input");
        const roleInput = roleInputDiv.querySelector("input");

        roleInputDiv.classList.add("d-none");
        hiddenInput.disabled = true;
        roleInput.disabled = true;

        // Reset validation for previously selected role input
        roleInput.value = "";
        roleInput.dispatchEvent(new Event("input")); // Trigger validation
    }

    // Toggle the clicked card
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

    // Enable or disable the Add button
    const anySelected = document.querySelectorAll(".clickable-card.selected").length > 0;
    addButton.disabled = !anySelected;

    // Trigger validation for the currently selected card's role input
    if (card.classList.contains("selected")) {
        roleInput.dispatchEvent(new Event("input")); // Trigger validation
    }
}


// Prevent click event from bubbling when clicking on the input field
document.querySelectorAll('.role-input input').forEach(input => {
    input.addEventListener('click', function (e) {
        e.stopPropagation();
    });
});

document.addEventListener('DOMContentLoaded', function () {
    flatpickr('.datetime-picker', {
        enableTime: true, // Enables time selection
        dateFormat: "d/m/Y H:i", // Matches your desired format (dd/MM/yyyy HH:mm)
        time_24hr: true // Enables 24-hour clock
    });
});


//function handleSelection(selectedCheckbox) {

//    const checkboxes = document.querySelectorAll("input[type='checkbox'][name='SelectedMovies']");

//    checkboxes.forEach((checkbox) => {
//        const cardFooter = checkbox.closest(".card-footer");

//        if (checkbox !== selectedCheckbox) {
//            if (selectedCheckbox.checked) {

//                cardFooter.style.display = "none";
//            } else {

//                cardFooter.style.display = "block";
//            }
//        }
//    });
//}

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
