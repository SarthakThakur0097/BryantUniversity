(async() => {
    const gebi = (e) => document.getElementById(e);

    async function changePeriod(periodId)
    {
        try{
            const response = await fetch ('http://localhost:51934/api/Calendar/' + periodId ,{
                method: "POST",
                credentials:"include",
                header:{
                    "Context-Type":"application/json"
                }
            });

            const data = await response.json();
            console.log(data);
            return data
        }
        catch(error){
            console.log('ERROR: ' + error);
        }
    }

    let dropDownMenu = gebi("period-list")
    let dropDownOptions = gebi("dropDownOptions")


    var selectedYear = dropDownMenu.textContent

    console.log(dropDownMenu)
    dropDownMenu.onclick = function () {
        let chosenPeriod = event.target
        var periodId = chosenPeriod.options[chosenPeriod.selectedIndex].value

        changePeriod(periodId)
    
       
    };

})();