let cheeses = [];
let milks = [];
let buyers = [];

getdataCheese();
getdataMilk();
getdataBuyer();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:37371/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CheeseCreated", (user, message) => {
        getdata();
    });

    connection.on("CheeseDeleted", (user, message) => {
        getdata();
    });

    connection.on("MilkCreated", (user, message) => {
        getdata();
    });

    connection.on("MilkDeleted", (user, message) => {
        getdata();
    });

    connection.on("BuyerCreated", (user, message) => {
        getdata();
    });

    connection.on("BuyerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

async function getdataCheese() {
   await fetch('http://localhost:37371/cheese')
        .then(x => x.json())
        .then(y => {
            cheeses = y;
            console.log(cheeses);
            displayCheese();
        });
}

async function getdataMilk() {
    await fetch('http://localhost:37371/milk')
        .then(x => x.json())
        .then(y => {
            milks = y;
            console.log(milks);
            displayMilk();
        });
}

async function getdataBuyer() {
    await fetch('http://localhost:37371/buyer')
        .then(x => x.json())
        .then(y => {
            buyers = y;
            console.log(buyers);
            displayBuyer();
        });
}

function displayCheese() {
    document.getElementById('resultsCheese').innerHTML = "";
    cheeses.forEach(t => {
        document.getElementById('resultsCheese').innerHTML +=
            "<tr><td>" + t.id +
            "</td><td>" + t.name +
            "</td><td>" + t.price +
            "</td><td>" + t.milkId +
            "</td><td>" + '<button type="button" onclick="removeCheese(${t.id})">Delete</button>' +
            " " + '<button type="button" onclick="updateCheese($"t.id})">Update</button>' +
            "</td></tr>";
    })
}

function displayMilk() {
    document.getElementById('resultsMilk').innerHTML = "";
    milks.forEach(t => {
        document.getElementById('resultsMilk').innerHTML +=
            "<tr><td>" + t.id +
            "</td><td>" + t.name +
            "</td><td>" + t.price +
            "</td><td>" + '<button type="button" onclick="removeMilk(${t.id})">Delete</button>' +
            " " + '<button type="button" onclick="updateMilk($"t.id})">Update</button>' +
            "</td></tr>";
    })
}

function displayBuyer() {
    document.getElementById('resultsBuyer').innerHTML = "";
    buyers.forEach(t => {
        document.getElementById('resultsBuyer').innerHTML +=
            "<tr><td>" + t.id +
            "</td><td>" + t.name +
            "</td><td>" + t.money +
            "</td><td>" + t.cheeseId +
            "</td><td>" + '<button type="button" onclick="removeBuyer(${t.id})">Delete</button>' +
            " " + '<button type="button" onclick="updateBuyer($"t.id})">Update</button>' +
            "</td></tr>";
    })
}

function removeCheese(id) {
    feetch('http://localhost:37371/cheese/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function removeMilk(id) {
    feetch('http://localhost:37371/milk/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function removeBuyer(id) {
    feetch('http://localhost:37371/buyer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function updateCheese(id) {
    let name = document.getElementById('cheesename').value;
    let price = document.getElementById('cheeseprice').value;
    let milkid = document.getElementById('cheesemilkid').value;
    fetch('http://localhost:37371/cheese/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { cheeseName: name, cheesePrice: price, cheeseMilkId: milkid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function updateMilk(id) {
    let name = document.getElementById('milkname').value;
    let price = document.getElementById('milkprice').value;
    fetch('http://localhost:37371/milk/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { milkName: name, milkPrice: price, }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function updateBuyer(id) {
    let name = document.getElementById('buyername').value;
    let price = document.getElementById('buyerprice').value;
    let milkid = document.getElementById('buyercheeseId').value;
    fetch('http://localhost:37371/buyer/' + id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { buyerName: name, buyerMoney: money, buyerCheeseId: cheeseid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function createCheese() {
    let name = document.getElementById('cheesename').value;
    let price = document.getElementById('cheeseprice').value;
    let milkid = document.getElementById('cheesemilkid').value;
    fetch('http://localhost:37371/cheese', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { cheeseName: name, cheesePrice: price, cheeseMilkId: milkid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdataCheese();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function createMilk() {
    let name = document.getElementById('milkname').value;
    let price = document.getElementById('milkprice').value;
    fetch('http://localhost:37371/milk', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { milkName: name, milkPrice: price, }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdataCheese();
        })
        .catch((error) => { console.error('Error: ', error); });
}

function createBuyer() {
    let name = document.getElementById('buyername').value;
    let price = document.getElementById('buyerprice').value;
    let milkid = document.getElementById('buyermilkid').value;
    fetch('http://localhost:37371/buyer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { buyerName: name, buyerMoney: money, buyerCheeseId: cheeseid }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdataCheese();
        })
        .catch((error) => { console.error('Error: ', error); });
}