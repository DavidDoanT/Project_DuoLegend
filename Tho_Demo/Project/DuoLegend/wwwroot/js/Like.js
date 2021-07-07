"use strict";

var likeConnection = new signalR.HubConnectionBuilder().withUrl("/likeHub").build();

var likeBtn = document.getElementById("likeButton");
likeConnection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});


likeBtn.addEventListener("click", function (event) {
    if (likeBtn.innerHTML == "Like") {
        likeBtn.innerHTML = "Unlike";
    } else {
        likeBtn.innerHTML = "Like";
    }
    var likerId = document.getElementById("liker").value;
    var userId = document.getElementById("user").value;
    likeConnection.invoke("AddLike", likerId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});