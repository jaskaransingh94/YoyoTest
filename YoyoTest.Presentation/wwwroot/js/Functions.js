function PrepareDropdownAndHideButtons(event) {
    //hide buttons
    event.currentTarget.parentElement.classList.toggle(hidden);
    //show dropdown
    let currentDropdown = event.currentTarget.parentElement.parentElement.querySelector(dropdown);

    let newDropdownData = [...dropdownData];
    newDropdownData.reverse();

    let dropdownContent = `<div class="dropdown-trigger">
                        <button class="button is-shadowless" aria-haspopup="true" aria-controls="dropdown-menu3">
                            <span>${newDropdownData[0]}</span>
                            <span class="icon is-small">
                                <i class="fas fa-angle-down" aria-hidden="true"></i>
                            </span>
                        </button>
                    </div>
                    <div class="dropdown-menu" role="menu">
                        <div class="dropdown-content">`;

    for (item of newDropdownData) {
        dropdownContent += `<a href="#" onmousedown="UpdatePlayerData(this,'${item}')" class="dropdown-item">${item}</a>`;
    }

    dropdownContent += `</div></div>`;

    currentDropdown.innerHTML = dropdownContent;
    currentDropdown.classList.toggle(hidden);
}


function UpdatePlayerDataById(isWarn, isStop, Id, levelInfo) {
    let playerIndex = playerData.findIndex(x => x.playerId == Id);

    if (isWarn) {
        playerData[playerIndex].isWarned = true;
    }
    if (isStop) {
        let levelData = levelInfo == null ? dropdownData[dropdownData.length - 1].split('-') : levelInfo.split('-');
        let level = parseInt(levelData[0]);
        let shuttle = parseInt(levelData[1]);
        playerData[playerIndex].speedLevel = level;
        playerData[playerIndex].shuttleNo = shuttle;
        playerData[playerIndex].isStopped = true;
    }
}

function UpdateSecondData(startTime) {
    if (!isTestStarted) {
        SetShuttleData();
        isTestStarted = true;
    }

    let presentTime = new Date().getTime();

    //set total time
    let totalCalculatedTime = presentTime - startTime;
    let totalMinutes = Math.floor((totalCalculatedTime % (1000 * 60 * 60)) / (1000 * 60));
    let totalSeconds = Math.floor((totalCalculatedTime % (1000 * 60)) / 1000);

    let totalDisplayMinutes = totalMinutes < 10 ? `0${totalMinutes}` : totalMinutes;
    let totalDisplaySeconds = totalSeconds < 10 ? `0${totalSeconds}` : totalSeconds;
    let totalDisplayTime = `${totalDisplayMinutes}:${totalDisplaySeconds}`;

    totalTime.innerText = `${totalDisplayTime} m`;

    UpdateShuttleData(totalDisplayTime);
}

function UpdateShuttleData(currentTime) {
    let nextShuttleStartTime = null;
    let shuttleTotalTime = testData[shuttleCount].levelTime;

    //check end of test
    if (shuttleCount + 1 === testData.length)
        nextShuttleStartTime = testData[shuttleCount].commulativeTime;
    else
        nextShuttleStartTime = testData[shuttleCount + 1].startTime;

    if (currentTime === nextShuttleStartTime) {
        if (shuttleCount + 1 === testData.length) { //check if its the last shuttle end the test
            TestCompleted();
            return;
        }
        ++shuttleCount;
        SetShuttleData();
    }

    // only update ui if a shuttle is in progress 
    if (currentShuttleTime != 0) {
        let updatedCurrentShuttleTime = --currentShuttleTime;
        let totalShuttleDisplaySeconds = currentShuttleTime < 10 ? `0${updatedCurrentShuttleTime}` : updatedCurrentShuttleTime;
        nextShuttle.innerText = `00:${totalShuttleDisplaySeconds} s`;

        //update progress bar
        const progress = (++progressSeconds / shuttleTotalTime) * 360;
        circle3Element.style.background = `conic-gradient(#e25555 1deg ${progress}deg, #ffffff ${progress + 1}deg)`;
    }
    else {
        //prepare dropdown after level finishes
        let content = `${testData[shuttleCount].speedLevel}-${testData[shuttleCount].shuttleNo}`;
        dropdownData.includes(content) ? null : dropdownData.push(content);

        progressSeconds = 0;
        //circle3Element.style.background = `none`;
        totalDistance.innerText = testData[shuttleCount].accumulatedShuttleDistance + ' m';
    }
}

function SetShuttleData() {
    currentShuttleTime = testData[shuttleCount].levelTime;
    levelInTimerElement.innerText = 'Level ' + testData[shuttleCount].speedLevel;
    shuttleInTimerElement.innerText = 'Shuttle ' + testData[shuttleCount].shuttleNo;
    speedInTimerElement.innerText = testData[shuttleCount].speed + ' km/h';
}

//toggle timer text and icon visibility
function TestStarted() {
    startIconElement[0].classList.toggle(hidden);
    startedTextElement.classList.toggle(hidden);
    startButton.style.cursor = 'none';
    startButton.style.pointerEvents = 'none';
}

//ui changes when test is completed
function TestCompleted() {
    clearInterval(interval);
    circle3Element.style.background = `none`;
    startedTextElement.classList.toggle(hidden);
    testCompletedElement.classList.toggle(hidden);
    testInfoElement.classList.toggle(hidden);
    viewResultsElement.classList.toggle(hidden);
}