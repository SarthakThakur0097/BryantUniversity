(async() => {
    const gebi = (e) => document.getElementById(e);

    let dropDownMenu = gebi("period-list")
    let dropDownOptions = gebi("dropDownOptions")
    let selectedYear = dropDownMenu.textContent

    console.log(dropDownMenu)
    dropDownMenu.onclick = function () {
        console.log(event.target.chil)
    };

})();