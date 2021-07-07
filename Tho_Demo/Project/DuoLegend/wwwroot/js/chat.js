
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

//wait for incoming message
//if message more than 8 delete at front-end old message
connection.on("ReceiveMessage", function (message, sender) {
    var div = document.createElement("div");
    document.getElementById("messagesList").appendChild(div);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    div.textContent = `${message}`;
    if (sender === document.getElementById("sender").value) {
        div.className = "message rightMessage";
        div = Right(div);
    }
    else {
        div.className = "message";
        div = Left(div);
    }
    var list = document.getElementById("messagesList");
    if (list.childNodes.length > 12) {
        list.removeChild(list.childNodes[4]);
    }
    var objDiv = document.getElementById("messagesList");
    objDiv.scrollTop = objDiv.scrollHeight;
});

//wait for incoming message
//when message come, add a notification box to header
connection.on("ReceiveNotification", function (inGameName, server, senderId, messageContent) {
    //listMessageContainer
    var a = document.createElement("a");
    document.getElementById("notificationBox").removeAttribute("hidden");
    document.getElementById("listMessageContainer").appendChild(a);
    if (document.getElementById(inGameName + server) == null) {
        a.textContent = `${inGameName}`;
        a.style.color = 'white';
        a.className = 'dropdown-item';
        a.href = '/Profile/ViewChat/' + inGameName + '/' + server;
        a.id = inGameName + server;
    }
    receiveMessageFromOtherBox(senderId, messageContent);
    //document.getElementById("listMessageContainer").click()
});

// start realtime (hub) connection between client and server
connection.start().then(function () {
    var sender = document.getElementById("userId").value;
    connection.invoke("Notification", sender).catch(function (err) {
        return console.error(err.toString());
    });
    openChat();
}).catch(function (err) {
    return console.error(err.toString());
});

//send message to server
document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    var sender = document.getElementById("sender").value;
    var receiver = document.getElementById("receiver").value;
    document.getElementById('messageInput').value = '';
    connection.invoke("SendMessage", message, sender, receiver).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//send message when user press enter
document.getElementById("messageInput").addEventListener("keyup", function (event) {
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) { //13 is code of enter button
        event.preventDefault();
        document.getElementById("sendButton").click();
    }
});


//load old message when user open chat
document.getElementById("openChatButton").addEventListener("click", function init (event) {
    document.getElementById("sendButton").disabled = false;
    document.getElementById("sendButton").click();
    var sender = document.getElementById("sender").value;
    var receiver = document.getElementById("receiver").value;
    connection.invoke("InitMessage", sender, receiver).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("openChatButton").removeEventListener("click", init);
});

//delete chat when chat box contain more than [numberOfElement] message
function DeleteChat(numberOfElement, ParentId) { //delete chat trong khung chat, de khung chat ko bi qua dai
    var a = Document.getElementById(ParentId);
    var child = a.children;
    if (child.length > numberOfElement) {
        a.removeChild(a.childNodes[0]);
    }
}