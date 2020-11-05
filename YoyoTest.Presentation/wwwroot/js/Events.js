//handle dropdown open and close
dropdownList.forEach(item => {
    item.addEventListener('click', event => {
        event.currentTarget.classList.toggle(active);
    })
})

dropdownList.forEach(item => {
    item.addEventListener('focusout', (event) => {
        event.currentTarget.classList.toggle(active);
    });
});


//handle player stop click
warnPlayerList.forEach(item => {
    item.addEventListener('click', event => {
        //change colour and text of warn button
        event.currentTarget.classList.toggle(greyedBg);
        event.currentTarget.innerText = warned;
        //remove event and cursor
        event.currentTarget.style.cursor = 'none';
        event.currentTarget.style.pointerEvents = 'none';

        let id = event.currentTarget.parentElement.dataset.id;
        UpdatePlayerDataById(true, false, id, null)
    })
});

//On start icon button click
startButton.addEventListener('click', event => {
    TestStarted();

    //display button when test is started
    playerButtonsElement.forEach(item => {
        item.classList.toggle(hidden);
    })

    const startTime = new Date().getTime(); //start time of the test
    interval = setInterval(function () { UpdateSecondData(startTime) }, 1000);
});

//handle player warning click
stopPlayerList.forEach(item => {
    item.addEventListener('click', event => {
        PrepareDropdownAndHideButtons(event);

        //check if its the last player that is active
        let playerInfoElements = Array.from(playerButtonsElement);
        let deactivatedPlayers = playerInfoElements.filter(elem => elem.className.includes(hidden));

        //clear interval and modify cirlce
        if (deactivatedPlayers.length === playerInfoElements.length) {
            TestCompleted();
        }

        let id = event.currentTarget.parentElement.dataset.id;
        UpdatePlayerDataById(false, true, id, null)
    });
});

//can be used for ajax call for updating the data in the db
function UpdatePlayerData(element, levelInfo) {
    let id = element.parentElement.parentElement.parentElement.dataset.id;
    element.parentElement.parentElement.previousElementSibling.firstElementChild.firstElementChild.innerText = levelInfo;
    UpdatePlayerDataById(false, true, id, levelInfo)
}