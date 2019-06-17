/// <reference path="jquery1.42.min.js" />

// 全局变量a和b，分别获取用户框和密码框的value值
var a = document.getElementsByName("Phonenum").value;
var b = document.getElementsByName("Pwd").value;
var c = document.getElementsByName("Pwd2").value;


// 验证手机号
function isPhoneNo(phone) {
    var pattern = /^1[34578]\d{9}$/;
    return pattern.test(phone);
}

function YzName(name) {
    $.ajax({
        url: "https://localhost:44370/api/login/GetUsers/" + name,
        success: function (data) {
            if (data.length > 0) {
                return "true";
            }
            else {
                return "false";
            }
        }
    })
}

//用户框失去焦点后验证value值
function oBlur_1(txt) {
    if (isPhoneNo(txt) == false) {
        document.getElementById("remind_1").innerHTML = "请输入正确的手机号码！";
    } else if (txt=="") { //用户框value值为空
        document.getElementById("remind_1").innerHTML = "请输入用户名！";
    } else if (YzName(txt)!="true") {
        document.getElementById("remind_1").innerHTML = "该用户名已被使用,请重新输入！";
    } else { //用户框value值不为空
        document.getElementById("remind_1").innerHTML = "";
    }
    
}

function oBlur_4(txt) {
    if (isPhoneNo(txt) == false) {
        document.getElementById("remind_4").innerHTML = "请输入正确的手机号码！";
    } else if (txt=="") { //用户框value值为空
        document.getElementById("remind_4").innerHTML = "请输入用户名！";
    } else { //用户框value值不为空
        document.getElementById("remind_4").innerHTML = "";
    }

}

//密码框失去焦点后验证value值
function oBlur_2(txt) {
    if (txt=="") { //密码框value值为空
        document.getElementById("remind_2").innerHTML = "请输入密码！";
    } else { //密码框value值不为空
        document.getElementById("remind_2").innerHTML = "";
    }
}

function oBlur_5(txt) {
    if (txt=="") { //密码框value值为空
        document.getElementById("remind_5").innerHTML = "请输入密码！";
    } else { //密码框value值不为空
        document.getElementById("remind_5").innerHTML = "";
    }
}

//密码框失去焦点后验证value值
function oBlur_3() {
    if (b!=c) { //密码框value值为空
        document.getElementById("remind_3").innerHTML = "请正确输入密码！";
    } else { //密码框value值不为空
        document.getElementById("remind_3").innerHTML = "";
    }
}

//用户框获得焦点的隐藏提醒
function oFocus_1() {
    document.getElementById("remind_1").innerHTML = "";
}
function oFocus_4() {
    document.getElementById("remind_4").innerHTML = "";
}

//密码框获得焦点的隐藏提醒
function oFocus_2() {
    document.getElementById("remind_2").innerHTML = "";
}
function oFocus_5() {
    document.getElementById("remind_5").innerHTML = "";
}

