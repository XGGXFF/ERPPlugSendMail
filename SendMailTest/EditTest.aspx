<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTest.aspx.cs" Inherits="SendMailTest.EditTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文本编辑框Demo</title>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="ueditor/ueditor.all.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="https://cdn.bootcss.com/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="scripts/TemplateJS.js"> </script>

    <style type="text/css">
        div {
            width: 100%;
        }
    </style>
</head>
<body>
    <div class="center-block" style="width: 1024px;">
        <div class="container" style="width: 1024px; background-color: cornflowerblue">
            <div class="col-lg-3">模板选择</div>
            <div class="col-lg-2 col-md-push-7">
                <select class="selectpicker" onchange="LoadTemplate()" id="templateId">
                    <option value="1">模板1</option>
                    <option value="2">模板2</option>
                    <option value="3">模板3</option>
                </select>
            </div>
        </div>

        <script id="editor" type="text/plain" style="height: 500px;"></script>

        <br />
        <div class="container" style="width: 1024px;">
            <div class="col-lg-2 col-md-push-4">
                <button id="saveText" class="btn-block" onclick="saveEditor()">存为模板</button>
            </div>
            <div class="col-lg-2 col-md-push-4">
                <button id="deleteText" class="btn-block" onclick="createEditor()">删除模板</button>
            </div>
            <div class="col-lg-2 col-md-push-4">
                <button id="sendMail" class="btn-block" onclick="deleteEditor()">发送生产通知</button>
            </div>
            <div class="col-lg-2 col-md-push-4">
                <button id="cancle" class="btn-block" onclick="deleteEditor()">取消发送通知</button>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('editor');

        function createEditor() {
            enableBtn();
            UE.getEditor('editor');
        }

        function enableBtn() {
            $("#saveText").show();
            $("#editorText").hide();
        }

        function disableBtn() {
            $("#saveText").hide();
            $("#editorText").show();
        }

    </script>
</body>
</html>
