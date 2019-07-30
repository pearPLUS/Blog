// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// label submit 
$(document).on("click", ".label_close_button", function () {
    $(this).parent().css({ "display": "none" });

});

$(document).on("click", ".submit", function () {
    var str = "";
    var labels = $(".B_label");
    labels.each(function () {
        if ($(this).css("display") === "inline-block") {

            str += $(this).attr("value") + ",";
        }

    });

    $(".label_input").val(str);


});



// parent comment input 



$(document).ready(function () {
    console.log("adada")
    if ($(".comment_user").val() == "") {
        $(".comment_input").prop('disabled', true);
        $(".comment_input").attr('placeholder', "请先登录在进行评论~~~")
    }
});


$(document).on("click", ".comment_input", function () {
    console.log("adada111");
    var input = $(this);
    commentReplyFlag = $(this).parent().find(".commentFlag").val();
    if (commentReplyFlag == "false") {
        console.log("adad");
        if (input.val() == "") {
            if ($(window).width() > 420) {
                input.animate({ "width": "87%" }, 100);
                input.css({ "background": "white", "border-color": "gray" })
                input.parent().find(".comment_submit").animate({ "width": "10%", "padding": "9px 10px", "margin-left": "10px", "float": "none" }, 100);
                input.parent().find(".commentFlag").val("true");
            }
        }

    }
    event.stopPropagation();
});


$(window).click(function () {
    $(".comment_input").each(function () {
        commentReplyFlag = $(this).parent().find(".commentFlag").val();
        if (commentReplyFlag == "true" ) {
            var input = $(this)
            if (input.val() == "") {
                input.animate({ "width": "97%" }, 100);
                input.css({ "background": "#eee", "border-color": "#ddd" })
                input.parent().find(".comment_submit").animate({ "width": "0%", "padding": "0", "margin-left": "0px" }, 90);
                input.parent().find(".commentFlag").val("false");
            }
        }
    });
    
    
});


// child comment input

// display the child comment reply form

$(document).on("click", ".comment_child_reply", function () {
    var childReplyFlag = $(this).attr("flagValue");
    console.log(childReplyFlag);
    if (childReplyFlag == "false") {
        $(this).find("span").text("取消回复");
        $(this).parent().parent().find(".child_func").css({ "display": "block" });
        $(this).parent().find(".comment_hidden_info").each(function () {
            $(this).addClass("comment_hidden_info_show");
        });
        $(this).attr("flagValue", "true");
    }
    else {
        $(this).find("span").text("回复");
        $(this).parent().parent().find(".child_func").css({ "display": "none" });
        $(this).parent().find(".comment_hidden_info").each(function () {
            $(this).removeClass("comment_hidden_info_show");
        });
        $(this).attr("flagValue", "false");
    }
});


//comment detail close
$(".comment_detail_close").click(function () {
    
    $(".comment_detail_wrap").css({ "display": "none" });
})