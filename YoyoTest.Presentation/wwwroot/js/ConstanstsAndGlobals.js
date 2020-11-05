//global variables
let interval = null;
let shuttleCount = 0;
let isTestStarted = false;
let currentShuttleTime = 0;
let progressSeconds = 0;
let dropdownData = ["0-0"];

//classes to modifiable elements in the dom
const startIcon = "start-icon";
const startedText = "started-text";
const timer = "start-timer";
const shuttleData = "shuttle";
const totalTimeData = "time";
const totalDistanceData = "distance";
const levelInTimer = "level-number";
const shuttleInTimer = "shuttle-number";
const speedInTimer = "speed-number";
const testCompleted = "test-completed";
const testInfo = "test-info";
const viewResults = "view-results";
const circle3 = "circle3";

//Data attributes
const playerButtonsAttribuute = '[data-buttons="stage"]';

//Class Reference
const dropdown = ".dropdown";
const dropdownItem = ".dropdown-item";
const stopPlayer = ".stop-player";
const warnPlayer = ".warn-player";

//elements of above classes
let startButton = document.getElementsByClassName(timer)[0];
let nextShuttle = document.getElementById(shuttleData);
let totalTime = document.getElementById(totalTimeData);
let totalDistance = document.getElementById(totalDistanceData);
let startIconElement = document.getElementsByClassName(startIcon);
let startedTextElement = document.getElementsByClassName(startedText)[0];
let levelInTimerElement = document.getElementsByClassName(levelInTimer)[0];
let shuttleInTimerElement = document.getElementsByClassName(shuttleInTimer)[0];
let speedInTimerElement = document.getElementsByClassName(speedInTimer)[0];
let testCompletedElement = document.getElementsByClassName(testCompleted)[0];
let testInfoElement = document.getElementsByClassName(testInfo)[0];
let viewResultsElement = document.getElementsByClassName(viewResults)[0];
let circle3Element = document.getElementsByClassName(circle3)[0];

//List of elements
let playerButtonsElement = document.querySelectorAll(playerButtonsAttribuute);
let dropdownList = document.querySelectorAll(dropdown);
let dropdownItemList = document.querySelectorAll(dropdownItem);
let stopPlayerList = document.querySelectorAll(stopPlayer);
let warnPlayerList = document.querySelectorAll(warnPlayer);

//Utility Classes
const active = "is-active";
const hidden = "is-hidden";
const greyedBg = "has-background-grey-light";

//Text Changes
const warned = "Warned"