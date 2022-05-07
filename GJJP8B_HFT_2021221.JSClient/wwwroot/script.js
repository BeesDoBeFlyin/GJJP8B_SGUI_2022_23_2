fetch('http://localhost:37371/cheese')
    .then(x => x.json())
    .then(y => console.log(y));