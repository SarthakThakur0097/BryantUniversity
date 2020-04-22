﻿(async() => {

    const gebi = (e) => document.getElementById(e);

    async function getCourseByTitle(title) {
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

})();