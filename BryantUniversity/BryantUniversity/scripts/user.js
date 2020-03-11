(async() => {

    const gebi = (e) => document.getElementById(e);
    const url = 'http://localhost:51934/api/User/'

    async function changeUsers(roleId)
    {
        try{
            const response = await fetch (url + roleId, {
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
        let headers = '<th scope="col">Name</th> <th scope="col">Email</th>'

        tableRow.innerHTML = headers;
        
        for (let i=0; i < rows.length; i++){
            var currUser = toDisplay[i]
            tbody.innerHTML+= `<td>${currUser.Name}</td> <td>${currUser.Email}</td>`  
            }
        }

    let dropDownMenu = gebi("role-list")
    let dropDownOptions = gebi("dropDownOptions")
    let selectedRole = dropDownMenu.textContent

    console.log(dropDownMenu)
    dropDownMenu.onclick = function () {
        let chosenRole = event.target
        let roleId = chosenRole.options[chosenRole.selectedIndex].value

        console.log(roleId)

        if (roleId == 'Admin') {
            roleId = 1
        } else if (roleId == 'Faculty') {
            roleId = 2
        } else if (roleId == 'Researcher') {
            roleId = 3
        } else if (roleId == 'Student') {
            roleId = 4
        }

        await updateList(changeUsers(roleId));
    };

})();