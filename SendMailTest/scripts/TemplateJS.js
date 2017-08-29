var templateList = function () {
    var templatelist = [];
    var templateVM = new Vue({
        el: '#templateId',
        data: { templatelist }
    });

    $.ajax({
        url: 'EditTest.aspx/GetAllTemplate',
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        type: 'POST',
        data: '', //参数
        success: function (result) {//成功后执行的方法
            templatelist = result.d;
            templateVM.data = [{ templateID: 1, templateName: '模板1' }]
            alert("获取模板数据成功！"); // 后台返回值
        },
        error: function (result) {//失败执行的方法
            alert("加载模板数据失败！" + result.responseText);
        }
    });
}

function saveEditor() {
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

function sendMaile() {
    var fileContent = UE.getEditor('editor').getContent();
    fileContent = fileContent.replace(/"/g, "&quot;");
    $.ajax({
        url: 'EditTest.aspx/SendMail',
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        type: 'POST',
        data: '{fileContent:"' + fileContent + '"}', //参数
        success: function (result) {//成功后执行的方法
            alert("邮件发送成功！"); // 后台返回值
        },
        error: function (result) {//失败执行的方法
            alert("邮件发送失败:" + result.responseText);
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
