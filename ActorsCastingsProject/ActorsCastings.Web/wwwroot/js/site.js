function toggleSelection(card) {
    const selectedCard = document.querySelector(".clickable-card.selected");
    const addButton = document.getElementById("add-selected-button");

    // Deselect the previously selected card
    if (selectedCard && selectedCard !== card) {
        selectedCard.classList.remove("selected");
        const hiddenInput = selectedCard.querySelector("input[type='hidden']");
        const roleInputDiv = selectedCard.querySelector(".role-input");
        const roleInput = roleInputDiv.querySelector("input");

        hiddenInput.disabled = true;
        roleInput.disabled = true;
        roleInputDiv.classList.add("d-none");
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
}

// Prevent click event from bubbling when clicking on the input field
document.querySelectorAll('.role-input input').forEach(input => {
    input.addEventListener('click', function (e) {
        e.stopPropagation();
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

//window.onload = function () {
//    const checkboxes = document.querySelectorAll("input[type='checkbox'][name='SelectedMovies']");
//    let selectedCheckbox = null;

//    checkboxes.forEach((checkbox) => {
//        if (checkbox.checked) {
//            selectedCheckbox = checkbox;
//        }
//    });

//    if (selectedCheckbox) {
//        handleSelection(selectedCheckbox);
//    }
//};