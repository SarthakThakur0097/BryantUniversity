﻿(async() => {

    const gebi = (e) => document.getElementById(e);
    let patternString;
    let timeString;
    let chosenBuildingId;
    let chosenRoomId;
    let chosenSemPeriodId;

    async function GetAllFaculty(RoleId)
    {
        try{
            const response = await fetch ('http://localhost:51934/api/User/' + RoleId,{
                method: "GET",
                credentials:"include",
                header:{
                    "Context-Type":"application/json"
                }
            });

            const data = await response.json();
            console.log(data);
            console.log("JSON: " + JSON.stringify(data))
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    function resetList(){
        let container = gebi("tableContainer");
        container.innerHTML =
        `<table id="list" class="pure-table pure-table-horizontal">
      <thead>
          <tr>
          </tr>
      </thead>
      <tbody>
              <tr data-numseats= data-id= class="bench-row">
                  <td>
                  </td>
              </tr>

      </tbody>
  </table>`
    }

    async function PopulateTable()
    {
        let table = gebi("TeachersTable");
        table.className = "table table-striped table-bordered table-sm";
       
        let toDisplay = await GetAllFaculty(2);
       
        var teachers = toDisplay;
        let rows = table.getElementsByTagName("tr");
        rows[0].style.display = "";

        let childNodes = table.childNodes
        console.log("Body: ");
        console.log(childNodes);
        let tableHead = childNodes[1];

        let tbody = childNodes[3];
        console.log(tbody)
        let tableRow = childNodes[1].childNodes[1];

        for (let i=0; i < toDisplay.length; i++){
           
            var teacher = toDisplay[i];

            tbody.innerHTML+= `<td>${teacher.Id}</td> <td>${teacher.Name}</td> <td>${teacher.Email}</td> <td><div id="AssignButtons"><button type="button" data-teacher-id=${teacher.Id} class="btn btn-success" >Assign</button></div></td>`
        }
    }
   
    await PopulateTable();
    let assignButton = gebi("tableContainer");

    console.log(assignButton);

    async function AssignToCourse(teacherId, courseID){
        try{
                console.log("ASDASD" + chosenSemPeriodId)
                let courseSection = {CourseId: courseID, RoomId: chosenRoomId, UserId: teacherId, SemesterPeriodId: chosenSemPeriodId}
                const response = await fetch('http://localhost:51934/api/Coursesection/Assign', {
                method: "POST",
                credentials: "include",
                headers: {
                "Content-Type": "application/json"
                },
                body: JSON.stringify(courseSection)
                });
if (response.ok) {
    const data = await response.json();
    if(data.error.length == 0){
        window.location.href = data.redirectUrl
        return data
    }

    else{
        window.alert("ERROR: A course this teacher is currently conficts with the course they are trying to be assigned to!")
    }
    
	console.log("JSON: " + JSON.stringify(data))
	
} else {
	// TODO handle errors returned from the server
}
            const data = await response.json();
            console.log(data.redirectUrl);
            console.log("JSON: " + JSON.stringify(data))
           
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    
    async function GetAllSemesterPeriods(){
        try{
                const response = await fetch ('http://localhost:51934/api/Calendar/Periods',{
                method: "GET",
                credentials:"include",
                header:{
                    "Context-Type":"application/json"
                }
            });

            const data = await response.json();
            console.log(data);
            console.log("JSON: " + JSON.stringify(data))
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    async function GetAllBuildings(){
        try{
            // var courseSection = {CourseId:courseID,  }
            const response = await fetch ('http://localhost:51934/api/Buildings/All',{
                method: "GET",
                credentials:"include",
                header:{
                    "Context-Type":"application/json"
                }
            });

          
            const data = await response.json();
            console.log("Returned Data from GetAllBuildings is: ")
            console.log(data);
            //console.log("JSON: " + JSON.stringify(data))
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    async function GetAllRoomsByBuildingId(buildingId){
        
        try{
                const response = await fetch ('http://localhost:51934/api/Buildings/' + buildingId + '/Rooms',{
                method: "GET",
                credentials:"include",
                header:{
                    "Context-Type":"application/json"
                }
            });

            const data = await response.json();
            console.log(data);
            console.log("JSON: " + JSON.stringify(data))
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    assignButton.onclick = function() {
        let butt = event.target;
        let courseId = gebi("getCourseId").dataset.courseId;
        let teacherId = butt.dataset.teacherId;

        if((chosenBuildingId != undefined || null) && (chosenRoomId != undefined || null) && (chosenSemPeriodId != undefined || null)){
            AssignToCourse(teacherId, courseId);
        }
        else{
            window.alert("Please chose an option from all the drop down menu's");
        }
    }

  
    async function setUpSemPeriodDropDown(){
        let buildingOptions = gebi("SemPeriodOptions")
        let toDisplay = await GetAllSemesterPeriods();

        for(let i = 0; i<toDisplay.length; i++)
        {
            let semPeriod = toDisplay[i]
            buildingOptions.innerHTML+= ` <a class="dropdown-item" data-period-id=${semPeriod.Id} href="#">${semPeriod.Period.Value}</a>`
        }
    }

    async function setUpBuildingDropDown(){

        console.log("Start of building method")
        let buildingOptions = gebi("BuildingOptions")

        let toDisplay = await GetAllBuildings();

        console.log("Buildings list: ")
        console.log(toDisplay)
        for(let i = 0; i<toDisplay.length; i++)
        {
            let building = toDisplay[i]
            console.log("Building Id is: ")
            console.log(building.Id)
            buildingOptions.innerHTML+= ` <a class="dropdown-item" data-building-id=${building.Id} href="#">${building.BuildingName}</a>`
        }
    }

    async function setUpRoomDropDown(){
        debugger;
        resetList("RoomDiv","Rooms", "RoomOptions", "dropdownRoom");

        let buildingOptions = gebi("RoomOptions");
        let toDisplay = await GetAllRoomsByBuildingId(chosenBuildingId);

        for(let i = 0; i<toDisplay.length; i++)
        {
            let room = toDisplay[i]
            buildingOptions.innerHTML+= ` <a class="dropdown-item" data-room-id=${room.Id} href="#">${room.Id}</a>`
        }
    }

    async function resetList(divId, dropDownTitle, dropDownId, labelledby){

        let options = gebi(divId);
        options.innerHTML = `<button class="btn btn-secondary dropdown-toggle" type="button" id="dropDownRoomButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                ${dropDownTitle}
                            </button>
                            <div class="dropdown-menu" id="${dropDownId}" aria-labelledby="${labelledby}">

                            </div>`
    }

    let semPeriodDiv = gebi("SemPeriodDiv");
    semPeriodDiv.onclick = function (){

        let chosenPeriod = event.target;
        let dropDownDisplay = gebi("semPeriodButton");
      
        if(chosenPeriod.text != dropDownDisplay && chosenPeriod.text != undefined)
        {
            dropDownDisplay.innerText = chosenPeriod.text;
        }
        chosenSemPeriodId = chosenPeriod.dataset.periodId;
    }

    let choosePattern = gebi("PatternDiv");
    choosePattern.onclick = function (){
        let patternButton = event.target;
        patternString = patternButton.text
        let dropDownDisplay = gebi("dropdownPatternButton");

        if(patternButton.text != dropDownDisplay && patternButton.text != undefined)
        {
            dropDownDisplay.innerText = patternButton.text;
        }  
    }
    let chooseTime = gebi("TimeDiv");
    chooseTime.onclick = function (){

        let timeButton = event.target;
        timeString = timeButton.text
        let dropDownDisplay = gebi("dropDownTimeButton");

        if(timeButton.text != dropDownDisplay && timeButton.text != undefined)
        {
            dropDownDisplay.innerText = timeButton.text;
        }
        
    }

    let timeButton = gebi("TimeButton")

    timeButton.onclick = function(){
        var now= moment();
        // 7 hour time span
        var timeSpan = moment.duration('PT7H');

        // addition
        alert(now.add(timeSpan).format());
    //    let startTime = gebi("startTime");
    //    var timeSplit = startTime.value.split(':'),
    //                    hours,
    //                    minutes,
    //                    meridian;
    //hours = timeSplit[0];
    //minutes = timeSplit[1];
    //if (hours > 12) {
    //    meridian = 'PM';
    //    hours -= 12;
    //} else if (hours < 12) {
    //    meridian = 'AM';
    //    if (hours == 0) {
    //        hours = 12;
    //    }
    //} else {
    //    meridian = 'PM';
    //}
    //alert(hours + ':' + minutes + ' ' + meridian);
    }
    let buildingDiv = gebi("BuildingDiv");
    buildingDiv.onclick = function (){ 

        console.log("Event Target is: ")
        console.log(event.target)
        let chosenBuilding = event.target;
        let dropDownDisplay = gebi("dropdownBuildingButton");

        if(chosenBuilding.text != dropDownDisplay && chosenBuilding.text != undefined)
        {
            dropDownDisplay.innerText = chosenBuilding.text;
        }
       
        chosenBuildingId = chosenBuilding.dataset.buildingId;
        console.log("Right before setupRoom()")
        setUpRoomDropDown();
    }

    let roomDiv = gebi("RoomDiv");
    roomDiv.onclick = function (){
        let chosenRoom = event.target;
        let dropDownDisplay = gebi("dropDownRoomButton");

        if(chosenRoom.text != dropDownDisplay && chosenRoom.text != undefined)
        {
            dropDownDisplay.innerText = chosenRoom.text;
        }
        chosenRoomId =  chosenRoom.dataset.roomId;
    }

    setUpSemPeriodDropDown()
    setUpBuildingDropDown();

})();