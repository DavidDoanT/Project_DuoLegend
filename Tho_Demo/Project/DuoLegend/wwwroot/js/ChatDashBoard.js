//doan nay dai vl, se chuyen thanh file js rieng
// Add active class to the current button (highlight it)
var list = document.getElementById("myList");
var options = list.getElementsByClassName("myChoose");
for (var i = 0; i < options.length; i++) {
    options[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("chosen");
        current[0].className = current[0].className.replace(" chosen", "");
        this.className += " chosen";
    });
}
function Right(div) {
    var textContent = div.textContent;
    var avatarPath = document.getElementById("UserSelfAvatarPath").value;
    div.innerHTML = "";
    div.className = "message message--self";
    var avatarContainer = document.createElement("div");
    var image = document.createElement("img");
    image.className = "msg-avatar";
    image.src = avatarPath;

    avatarContainer.className = "message__avatar";
    avatarContainer.appendChild(image);
    div.appendChild(avatarContainer);
    var chatContentContainer = document.createElement("div");
    chatContentContainer.className = "message__body message--self__body";
    chatContentContainer.textContent = textContent;
    div.appendChild(chatContentContainer);
}

function Left(div) {
    var textContent = div.textContent;
    var avatarPath = document.getElementById("UserOtherAvatarPath").value;
    div.innerHTML = "";
    div.className = "message message--other";
    var avatarContainer = document.createElement("div");
    var image = document.createElement("img");
    image.className = "msg-avatar";
    image.src = avatarPath;

    avatarContainer.className = "message__avatar";
    avatarContainer.appendChild(image);
    div.appendChild(avatarContainer);
    var chatContentContainer = document.createElement("div");
    chatContentContainer.className = "message__body";
    chatContentContainer.textContent = textContent;
    div.appendChild(chatContentContainer);
}

function openChat() {
    document.getElementById("openChatButton").click();
}

function receiveMessageFromOtherBox(senderId, messageContent) {
    var messageList = document.getElementById("myList");
    var floatBox = document.getElementById("id" + senderId);
    messageList.removeChild(floatBox);
    messageList.insertBefore(floatBox, messageList.childNodes[1]);
    var boxContent = document.getElementsByClassName("content" + senderId);
    boxContent[0].innerHTML = messageContent;
    boxContent[1].innerHTML = "just now";
    boxContent[2].innerHTML = "";
}

document.getElementById("sendButton").addEventListener("click", function (event) {
    content = document.getElementById("messageInput").value;
    if (content != "") {
        receiveMessageFromOtherBox(document.getElementById("receiver").value, content);
    }
});
document.getElementById("loadOldMessage").addEventListener("click", function (event) {
    var sender = document.getElementById("sender").value;
    var receiver = document.getElementById("receiver").value;
    var messageList = document.getElementById("messagesList");
    var loadOldMessageButton = document.getElementById("loadOldMessage");
    var numberOfMessage = messageList.children.length;
    messageList.innerHTML = "";
    messageList.appendChild(loadOldMessageButton);
    connection.invoke("LoadOldMessage", sender, receiver, numberOfMessage).catch(function (err) {
        return console.error(err.toString());
    });
});

function updateOnlineSate() {
    var InputObject = document.getElementsByClassName("UserIdArray");
    var userIdArray = [];
    var stateImg = document.getElementsByClassName("avatarState");
    for (var i = 0; i < InputObject.length; i++) {
        userIdArray.push(InputObject[i].value);
    }
    connection.invoke("SendCheckOnline", userIdArray, document.getElementById("sender").value).catch(function (err) {
        return console.error(err.toString());
    });
    for (var i = 0; i < stateImg.length; i++) {
        stateImg[i].src = '/img/off.png';
    }
}

window.onload = function () { // this will be run when the whole page is loaded
    document.getElementById("updateOnlineList").click();
};

setInterval(function () { document.getElementById("updateOnlineList").click(); }, 30000);