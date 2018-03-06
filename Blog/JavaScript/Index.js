var i = 1;
$(function () {
    $("#menu li a").mouseover(function () {
        $(this).parent("li").css({ "background-color": "#F15694", "border-radius": "5px" });

    })
    $("#menu li a").mouseout(function () {
        $(this).parent("li").css("background-color", "#6cc")
    })
    /* 位置信息显示(开始)  */
    var urlparth = window.location.pathname;
    var path = urlparth.split('/');
    var controllername = path[path.length - 2];
    var wz = 0;
    switch (controllername)
    {
        case "Index": wz = 0; break;
        case "LearningNotes": wz = 1; break;
        case "MessageBoard": wz = 2; break;
        case "AboutMe": wz = 3; break;
    }
    if (wz != 0) {
        $("#daohang").append("><a href='/'>" + $("#menu li a").eq(wz).html() + "</>");
    }
    else
    {
        $("#daohang").html("<a href='/'>首页</a></div>");
    }

    /* 位置信息显示(结束) */

    //$("#menu li a").click(function (e) {
    //    if ($("#daohang").text().indexOf(">") == -1) {
    //        $("#daohang").append("><a href='/'>" + $(this).html() + "</>");
    //    }
    //    else {
    //        $("#daohang").html("<a href='/'>首页</a></div>");
    //        $("#daohang").append("><a href='/'>" + $(this).html() + "</>");
    //    }
    //})
    var QH=window.setInterval(imgQH, 6000);
    load();
    $(window).resize(function () {
        load();
    });
    $("#view").children("img").mouseover(function ()
    {
        clearInterval(QH);
    })
    $("#view").children("img").mouseout(function ()
    {
        QH = window.setInterval(imgQH, 6000);
    })

})

function load() {
    var y = $("#view").offset().top;
    var x = $("#view").offset().left;
    var width = $("#view").width();
    $("#view").children("img").attr({ "width": width + "px", "height": "300px", "top": y + "px", "left": x + "px" });
    $("#my").css({ "position": "absolute", "top": y + "px", "left": x + width - 0.2 + "px" });
    var x1 = $("#my").offset().left;
    var width1 = $("#my").width();
    $("#right_content").css({ "position": "absolute", "top": y + "px", "left": x1 + width1 + 20 + "px" })

}

function imgQH() {
    $("#view").children("img").eq(i - 1).fadeOut(4000);
    if (i >= 3) {
        i = 0;
    }
    $("#view").children("img").eq(i).fadeIn(4000);
    i++;
}




//function GotoPartView(actionname, controllerName) {
//    var url = "/" + controllerName + "/" + actionname;
//    $('#content').attr("src", url);
//    //$.ajax({
//    //    type: "post",
//    //    url: url,
//    //    success: function (data) {
//    //        //获取到数据后在右侧Content下显示分部视图
//    //        $('#content').html(data);
//    //    }
//    //});
//}