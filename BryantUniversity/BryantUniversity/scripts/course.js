(async() => {

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
    //let dropDownMenu = gebi("period-list")
    //let dropDownOptions = gebi("dropDownOptions")
    //let selectedYear = dropDownMenu.textContent
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
        //resetList();
        let table = gebi("TeachersTable");
        table.className = "table table-striped table-bordered table-sm";
       
        let toDisplay = await GetAllFaculty(2);

        console.log("Display List")
        console.log(toDisplay)
       
        var teachers = toDisplay;
        let rows = table.getElementsByTagName("tr");
        rows[0].style.display = "";

        let childNodes = table.childNodes
        console.log("Body: ");
        console.log(childNodes);
        let tableHead = childNodes[1];
        //tableHead.className = "thead-dark"
        let tbody = childNodes[3];
        console.log(tbody)
        let tableRow = childNodes[1].childNodes[1];
        //let headers = '<th scope="col">Date</th> <th scope="col">Academic Event</th>'

        //tableRow.innerHTML = headers;
        for (let i=0; i < toDisplay.length; i++){
           
            var teacher = toDisplay[i];
            console.log("Teacher: " )
            console.log(teacher)
            //var items =  '<td>${data[0]}</td> <td>@Model.semesterDetails[i].EventDescription</td>'
            tbody.innerHTML+= `<td>${teacher.Id}</td> <td>${teacher.Name}</td> <td>${teacher.Email}</td> <td><div id="AssignButtons"><button type="button" data-teacher-id=${teacher.Id} class="btn btn-success" >Assign</button></div></td>`
        }
    }
   
    await PopulateTable();
    let assignButton = gebi("tableContainer");

    console.log(assignButton);

    async function AssignToCourse(teacherId, courseID){
        try{
            let courseSection = {CourseId:courseID, RoomId: chosenRoomId, UserId: teacherId, TimeSlot: timeString, SemesterPeriodId: chosenSemPeriodId }
            //const response = await fetch ('http://localhost:51934/api/Coursesection/' + teacherID +'/course/' + courseID +'/room/' + roomID +'/time/'+ timeString + '/pattern/' + patternString,{
            const response = await fetch ('http://localhost:51934/api/Coursesection/Assign' + courseSection ,{
                method: "POST",
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

    
    async function GetAllSemesterPeriods(){
        try{
            // var courseSection = {CourseId:courseID,  }
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
            console.log(data);
            console.log("JSON: " + JSON.stringify(data))
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    async function GetAllRoomsByBuildingId(buildingId){
        try{
            // var courseSection = {CourseId:courseID,  }
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
        console.log(teacherId)
      
        AssignToCourse(teacherId, courseId);
    }

    let choosePattern = gebi("PatternDiv");
    choosePattern.onclick = function (){
        let patternButton = event.target;
        patternString = patternButton.text
        
    }
    let chooseTime = gebi("TimeDiv");
    chooseTime.onclick = function (){
        let timeButton = event.target;
        timeString = timeButton.text
    }

    async function setUpSemPeriodDropDown(){
        let buildingOptions = gebi("SemPeriodOptions")
        let toDisplay = await GetAllSemesterPeriods();
        console.log("To Display: ")
        console.log(toDisplay)
        console.log(toDisplay);
        for(let i = 0; i<toDisplay.length; i++)
        {
            let semPeriod = toDisplay[i]
            buildingOptions.innerHTML+= ` <a class="dropdown-item" data-period-id=${semPeriod.Id} href="#">${semPeriod.Period.Value}</a>`
        }
    }

    async function setUpBuildingDropDown(){
        let buildingOptions = gebi("BuildingOptions")
        let toDisplay = await GetAllBuildings(2);

        for(let i = 0; i<toDisplay.length; i++)
        {
            let building = toDisplay[0]
            buildingOptions.innerHTML+= ` <a class="dropdown-item" data-building-id=${building.Id} href="#">${building.BuildingName}</a>`
        }
    }

    async function setUpRoomDropDown(){
        let buildingOptions = gebi("RoomOptions")
        let toDisplay = await GetAllRoomsByBuildingId(chosenBuildingId);

        console.log(toDisplay);
        for(let i = 0; i<toDisplay.length; i++)
        {
            let room = toDisplay[0]
            buildingOptions.innerHTML+= ` <a class="dropdown-item" data-room-id=${room.Id} href="#">${room.Id}</a>`
        }
    }

    let semPeriodDiv = gebi("SemPeriodDiv");
    semPeriodDiv.onclick = function (){
        let semPeriodOptions = gebi("SemPeriodOptions");
        let chosenPeriod = event.target;
        chosenSemPeriod = chosenPeriod.dataset.periodId;
        console.log(chosenSemPeriod);
    }

    let buildingDiv = gebi("BuildingDiv");
    buildingDiv.onclick = function (){ 
        console.log("Click")
        let buildingOptions = gebi("BuildingOptions");
        let chosenBuilding = event.target;
        chosenBuildingId = chosenBuilding.dataset.buildingId;
        console.log(chosenBuildingId);
        setUpRoomDropDown();
    }

    let roomDiv = gebi("RoomDiv");
    roomDiv.onclick = function (){
        let roomOptions = gebi("RoomOptions");
        let chosenRoom = event.target;
        chosenRoomId =  chosenRoom.dataset.roomId;
    }


    setUpSemPeriodDropDown()
    setUpBuildingDropDown();

})();