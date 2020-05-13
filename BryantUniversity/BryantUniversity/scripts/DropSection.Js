(async() => {
    const gebi = (e) => document.getElementById(e);

    let removeButtons = gebi("removeContainer");

    removeButtons.onclick = function(){
        debugger;
        let selected = event.target
        console.log(selected);
        console.log(selected.dataset.registrationId);

        const classToRemove = selected.dataset.registrationId;

        DropClass(classToRemove);
    }

    async function DropClass(id){

        try{
            const response = await fetch('http://localhost:51934/api/Registration/' + id, {
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