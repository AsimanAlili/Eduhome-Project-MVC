var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();

connection.start().then(function () {
    console.log("User connected");
}).catch(function (err) {
    return console.error(err);
});

$(document).ready(function () {
    connection.on("OrderAccepted", function (name) {
        alert("order accepted: " + name);
    })
})