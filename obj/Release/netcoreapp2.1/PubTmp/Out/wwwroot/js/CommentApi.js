//parent comment submit 
$(document).ready(function () {
    $(".comment_submit").click(function () {

        if ($(this).parent().find(".comment_input").val() == "") {
            alert("the comment is empty");
        }

        else {
            var data = {};
            if ($(this).attr("commentType") == "parent") {
                data["content"] = $(".comment_input").val();
                data["fkApplicationUser"] = $(".comment_user").val();
                data["fkBlog"] = $(".blog_id").val();
                data["ParentCommentId"] = null;
            }

            else if ($(this).attr("commentType") == "child") {
                data["content"] = $(this).parent().find(".comment_input").val();
                data["ParentCommentId"] = parseInt($(this).attr("commentId"));
                data["fkApplicationUser"] = $(".comment_user").val();
                data["fkBlog"] = null;
            }
            // set data




            console.log(JSON.stringify(data));

            $.ajax({
                method: "POST",
                url: "/api/blogcomment",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (data, status, jqXHR) {
                    location.reload(true);
                },
                error: function (jqXHR, status) {
                    // error handler
                    console.log(jqXHR);
                    alert('fail' + status.code);
                }
            });
        }
    });
});


// show comment detail
$(".show_detail").click(function () {
    $(".comment_detail_wrap").css({ "display": "block" });

    var urlAddress = "/api/blogcomment/" + $(this).attr("commentId");
    console.log(urlAddress);
    $.ajax({
        type: "GET",
        url: urlAddress,
        dataType: "json",
        success: function (data) {

            // clean the innerhtml
            $(".child_detail").empty();
            $(".child_detail").append("<div class='comment_title'><span>条评论</span></div>");
            var count = 0;
            $.each(data, function (index, element) {
                var time = element.postTime.split('T');
                if (index == 0) {

                    $(".comment_detail_container").find(".parent_detail").find(".comment_content").text(element.content);
                    $(".comment_detail_container").find(".parent_detail").find(".comment_user_name").text(element.applicationUser.userName)

                    $(".comment_detail_container").find(".parent_detail").find(".comment_time").text(time[0]);
                    $(".comment_detail_container").find(".parent_detail").find(".comment_func").find(".comment_submit").attr("commentid", element.id);
                }
                else {
                    count++;

                    var strHtml =

                        "<div class='comment_container_detail'>" +
                        "<div class='comment-meta'>" +
                        "<span class='comment_user_profile'></span>" +
                        "<span class='comment_user_name'>" + element.applicationUser.userName + "</span>" +
                        "<span class='reply'>回复</span>" +
                        "<span class='parent_comment_user'>" + element.parentCommentName + "</span>" +
                        "<span class='comment_time'>" + time[0] + "</span>" +
                        "</div>" +
                        "<span class='comment_content'>" + element.content + "</span>" +
                        "<ul class='comment-information'><li class='comment_show_info'><i class='fa fa-thumbs-up'></i>" + element.likeCount + "</li>"
                        + "<li class='comment_show_info comment_child_reply' flagValue='false'><i class='fa fa-reply'></i><span>回复</span></li></ul>" +
                        "<div class='comment_func child_func'>" +
                        "<input type='text' placeholder='写下你的评论...' class='comment_input' />" +
                        "<input type='button' value='发布' class='comment_submit' commentType='child' commentId='" + element.id + "' />" +
                        "<input type='hidden' class='commentFlag' value='false' />"
                        + "</div>"

                        + "</div>";



                    $(".child_detail").append(strHtml);
                }
                $(".child_detail").find(".comment_title").find("span").text(count + " 条评论");

            });
        },
        error: function (jqXHR, status) {
            console.log("xxxxx");
        }

    });
});