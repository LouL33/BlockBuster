let ColorClicker = () => {
    let _fullColor = $("#Color").val();
    $("#welcomeMessage").html(_fullColor);

};

let addAColor = (data) => {
    $("#colorList").append($("<li>").html(data.Color));
}


let talkToServer = () => {

    let newMarblesWithColor = {
        Color: $("#newMarbleColor").val()
    };

    $.ajax({
        url: '/api/Marbles',
        dataType: "json",
        contenetType: "application/json",
        //data: JSON.stringify(newMarblesWithColor),
        type: "POST",
        success: (data) => {
            console.log("success", data);
            addAColor(data);
        },
        error: (data) => {
            console.log("nahhh foo", data);
        },
        complete: (data) => {
            console.log("done", data);
        }
    });
};