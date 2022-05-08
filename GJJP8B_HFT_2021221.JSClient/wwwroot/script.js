let cheeses = [];

getdataCheese();

async function getdataCheese() {
   await fetch('http://localhost:37371/cheese')
        .then(x => x.json())
        .then(y => {
            cheeses = y;
            console.log(cheeses);
            displayCheese();
        });
}

function displayCheese() {
    document.getElementById('results').innerHTML = "";
    cheeses.forEach(t => {
        document.getElementById('results').innerHTML +=
        "<tr><td>" + t.id + "</td><td>" + t.name + "</td></tr>";
        console.log(t.name);
    })
}

function createCheese() {
    let name = document.getElementById('cheesename').value;
    fetch('http://localhost:37371/cheese', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { cheeseName: name }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdataCheese();
        })
        .catch((error) => { console.error('Error: ', error); });
}