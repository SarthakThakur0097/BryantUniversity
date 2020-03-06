(async() => {

    const gebi = (e) => document.getElementById(e);
    let patternString;
    let timeString;

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

    async function AssignToCourse(teacherID, courseID){
        try{
            const response = await fetch ('http://localhost:51934/api/Coursesection/' + teacherID +'/course/' + courseID + '/time/'+ timeString + '/pattern/' + patternString,{
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
    assignButton.onclick = function() {
        let butt = event.target;
        let courseId = gebi("getCourseId").dataset.courseId;
        let teacherId = butt.dataset.teacherId;
     
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
    
})();