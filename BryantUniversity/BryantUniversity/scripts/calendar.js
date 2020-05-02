(async() => {

    const gebi = (e) => document.getElementById(e);

    async function changePeriod(periodId)
    {
        try{
            const response = await fetch ('httpss://localhost:51934/api/Calendar/' + periodId ,{
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

    async function updateList(data){
       resetList();
       let table = gebi("list");
       table.className = "table";

       
        let toDisplay = await data;
        console.log("Display List")
        console.log()
       
        let rows = table.getElementsByTagName("tr");
        rows[0].style.display = "";

        let childNodes = table.childNodes
        console.log("Body: ");
        console.log(childNodes);
        let tableHead = childNodes[1];
        tableHead.className = "thead-dark"
        let tbody = childNodes[3];
        console.log(tbody)
        let tableRow = childNodes[1].childNodes[1];
        let headers = '<th scope="col">Date</th> <th scope="col">Academic Event</th>'

        tableRow.innerHTML = headers;

        for (let i=0; i < toDisplay.length; i++){

            var currEvent = await toDisplay[i]
            //var items =  '<td>${data[0]}</td> <td>@Model.semesterDetails[i].EventDescription</td>'

        
            tbody.innerHTML+= `<td>${currEvent.Date}</td> <td>${currEvent.EventDescription}</td>`
            
            }
        }

    let dropDownMenu = gebi("period-list")
    let dropDownOptions = gebi("dropDownOptions")
    let selectedYear = dropDownMenu.textContent

    console.log(dropDownMenu)
    dropDownMenu.onclick = function () {
        let chosenPeriod = event.target
        console.log("Event target is")
        console.log(chosenPeriod)
        let periodId = chosenPeriod.options[chosenPeriod.selectedIndex].value

        updateList(changePeriod(periodId));
    };

})();