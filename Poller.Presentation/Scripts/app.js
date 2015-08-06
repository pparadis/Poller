$(function () {
    var chat = $.connection.chatHub;
    chat.client.pushMessageToLeftBar = function (data) {
        var template = $.templates("#ContentTemplate");
        var htmlOutput = template.render(JSON.parse(data));
        $('#left-bar').prepend(htmlOutput);
    };

    chat.client.pushMessageToRightBar = function (data) {
        var template = $.templates("#ContentTemplate");
        var htmlOutput = template.render(JSON.parse(data));
        $('#right-bar').prepend(htmlOutput);
    };

    chat.client.pushImageToLeftBar = function (data) {
        var template = $.templates("#ImageTemplate");
        var htmlOutput = template.render(JSON.parse(data));
        $('#left-bar').prepend(htmlOutput);
    };

    chat.client.pushImageToRightBar = function (data) {
        var template = $.templates("#ImageTemplate");
        var htmlOutput = template.render(JSON.parse(data));
        $('#right-bar').prepend(htmlOutput);
    };

    chat.client.pushLinkToLeftBar = function (data) {
        var template = $.templates("#UrlTemplate");
        var htmlOutput = template.render(JSON.parse(data));
        $('#left-bar').prepend(htmlOutput);
    };

    chat.client.pushLinkToRightBar = function (data) {
        var template = $.templates("#UrlTemplate");
        var htmlOutput = template.render(JSON.parse(data));
        $('#right-bar').prepend(htmlOutput);
    };

    chat.client.pushVideoToLeftBar = function (message) {
        $('#left-bar').prepend('<div> <video width="320" height="240" autoplay loop muted preload><source src="' + htmlEncode(message) + '"></source></video></div>');
    };

    chat.client.clearDailyContent = function () {
        $('#left-bar').empty();
    };

    chat.client.reloadClient = function () {
        window.location = "/";
    };

    $.connection.hub.start().done(function () {
        $.ajax({
            method: "POST",
            url: "/ContentDisplay/ReloadContentColumns"
        });
    });
});

function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}