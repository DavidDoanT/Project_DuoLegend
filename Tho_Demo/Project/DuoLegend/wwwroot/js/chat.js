"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message, sender) {
    var div = document.createElement("div");
    document.getElementById("messagesList").appendChild(div);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    div.textContent = `${message}`;
    if (sender === document.getElementById("sender").value) {
        div.className = "leftMessage";
    }
    else {
        div.className = "rightMessage";
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    var sender = document.getElementById("sender").value;
    var receiver = document.getElementById("receiver").value;
    connection.invoke("SendMessage", message, sender, receiver).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});