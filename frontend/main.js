window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})

const productionApiUrl = 'https://visitorcounterfunction.azurewebsites.net/api/IncrementVisitCount?code=7pOMn_n4s2RWaK-DsNlb9cWKBisceEqRcjzWbvosRzV8AzFuM413qA%3D%3D';

const getVisitCount = () => {
    let count = 30;
    fetch(productionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count =  response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}