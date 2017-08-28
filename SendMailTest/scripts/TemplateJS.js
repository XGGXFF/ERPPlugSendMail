﻿function saveEditor() {
    var fileName = "templateOne.html";
    var fileContent = UE.getEditor('editor').getContent();
    fileContent = fileContent.replace(/"/g, "&quot;");
    $.ajax({
        url: 'EditTest.aspx/SaveTemplate',
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        type: 'POST',
        data: '{fileName:"' + fileName + '",fileContent:"' + fileContent + '"}', //参数
        success: function (result) {//成功后执行的方法
            alert("保存模板成功！"); // 后台返回值
        },
        error: function (result) {//失败执行的方法
            alert("保存模板失败:" + result.responseText);
        }
    });

}

function LoadTemplate() {
    var id = $("#templateId").val();
    $.ajax({
        url: 'EditTest.aspx/LoadTemplate',
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        type: 'POST',
        data: '{templeId:"' + id + '"}', //参数
        success: function (result) {//成功后执行的方法
            UE.getEditor('editor').setContent(result.d, false);
        },
        error: function (result) {//失败执行的方法
            alert("保存模板失败:" + result.responseText);
        }
    });
}