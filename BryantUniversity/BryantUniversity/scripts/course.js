(async() => {

    const gebi = (e) => document.getElementById(e);
   

    async function GetAllFaculty()
    {
        try{
            const response = await fetch ('http://localhost:51934/api/User/AllFaculty/',{
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
    //let dropDownMenu = gebi("period-list")
    //let dropDownOptions = gebi("dropDownOptions")
    //let selectedYear = dropDownMenu.textContent

    
    GetAllFaculty();
})();

//$(document).ready(function () {
//    $('#dtHorizontalVerticalExample').DataTable({
//        "scrollX": true,
//        "scrollY": 200,
//    });
//    $('.dataTables_length').addClass('bs-select');
//});