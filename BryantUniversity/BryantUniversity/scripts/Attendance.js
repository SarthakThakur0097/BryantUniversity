(async() => {

    const gebi = (e) => document.getElementById(e);

    let chosenTime;
    let datePicker = gebi("datetimepicker1");
    let submitButton = gebi("attended")
    let absentButton = gebi("absent")

    datePicker.onclick = function(){
        let time = gebi("datetimepicker1")
        chosenTime = time.childNodes[1];
        console.log(time.childNodes[1].value)
       

    }

    submitButton.onclick = function(){
        console.log("In submit button" + chosenTime.value)
        let timeString = chosenTime.value;
        let formatted = timeString.split("/")
        let yearAndTime = formatted[2].split(" ");

        console.log(formatted);
        console.log(yearAndTime);
        
        let cSharpTime = formatted[0] + '/' + formatted[1] + '/' + yearAndTime[0];
      
        InsertAttendanceTime(parseInt(formatted[0]), parseInt(formatted[1]), parseInt(yearAndTime[0]), true)


    }

    
    absentButton.onclick = function(){
        console.log("In submit button" + chosenTime.value)
        let timeString = chosenTime.value;
        let formatted = timeString.split("/")
        let yearAndTime = formatted[2].split(" ");

        console.log(formatted);
        console.log(yearAndTime);
        
        let cSharpTime = formatted[0] + '/' + formatted[1] + '/' + yearAndTime[0];
      
        InsertAttendanceTime(parseInt(formatted[0]), parseInt(formatted[1]), parseInt(yearAndTime[0]), false)


    }

    async function InsertAttendanceTime(month, day, year, present){
        
        let sectionId = parseInt(gebi("datacontainer").dataset.registrationId);
        let studentId = parseInt(gebi("datacontainer").dataset.studentId);

        try{
            const response = await fetch('https://bryantweb.azurewebsites.net/api/Attendance/' + month + '/day/' + day + '/year/' + year + '/section/' +sectionId + '/student/' + studentId + '/present/' + present, {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
            });
            if (response.ok) {
                const data = await response.json();
                if(data.error.length == 0){
                    window.location.href = data.redirectUrl
                    return data
                }

                else{
                    window.alert(data.error)
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
})();