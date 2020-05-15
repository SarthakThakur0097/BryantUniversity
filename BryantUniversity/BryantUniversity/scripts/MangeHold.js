(async() => {

    const gebi = (e) => document.getElementById(e);

    let removeButtons = gebi("removeContainer");

    removeButtons.onclick = function(){
        let selected = event.target
        console.log(selected);
        console.log(selected.dataset.studentHoldId);

        const holdToRemove = selected.dataset.studentHoldId;

        RemoveHold(holdToRemove);
    }

    async function RemoveHold(id){

        try{
            const response = await fetch('http://localhost:51934/api/StudentHolds/' + id, {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                }
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