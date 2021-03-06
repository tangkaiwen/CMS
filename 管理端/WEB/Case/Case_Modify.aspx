﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Case_Modify.aspx.cs" Inherits="WEB.Case.Case_Modify" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改</title>
    <link href="/css/edit.css" rel="stylesheet" />
    <script src="/js/jquery-1.8.3.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/jquery-uploadpop.js"></script>
    <script src="/js/common.js?v=1"></script>
    <script src="/ueditor1_4_3/ueditor.config.js"></script>
    <script src="/ueditor1_4_3/ueditor.all.js"></script>

    <!-- 实例化编辑器 -->
    <script type="text/javascript">
        $(function () {
            var _layer, isclose = true;
            if (layer.index == 1) {
                isclose = false;
            }
            else {
                _layer = $.tc.showWaiting("请稍等...", 0, 6);
            }
            var htmlContent = document.getElementById("<%=this.hide_Content.ClientID%>").value;
            //正确的初始化方式  阻止复制的div标签自动转换为p标签
            var ue = UE.getEditor('editor', { allowDivTransToP: false });
            //正确的初始化方式
            ue.ready(function () {
                //this是当前创建的编辑器实例
                this.setContent(htmlContent);
                if (isclose) {
                    layer.close(_layer);
                }

            });
            //给图片赋值
            var imgPath = document.getElementById("<%=this.hide_ImgPath.ClientID%>").value;
            $("#img").attr("src", imgPath);
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="clearfix ed-title">
                <h3>修改
                </h3>
                <div class="close">
                    <a onclick="CloseWindow()">
                        <img src="/Images/close.gif" />
                    </a>
                </div>
            </div>
            <div class="clearfix">
                <asp:Label CssClass="green" ID="ltMsg" Visible="false" runat="server">保存成功</asp:Label>
            </div>

            <table class="ed-table">
                <tr>
                    <td class="alignright">分类：</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCaseClass1"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="alignright">名称：</td>
                    <td>
                        <input type="text" runat="server" id="txtTitle" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red"
                            ControlToValidate="txtTitle" Display="Dynamic"
                            ErrorMessage="名称不能为空" SetFocusOnError="True">名称不能为空</asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="alignright">图片：</td>
                    <td>
                        <img id="img" runat="server" style="width: 100px; height: 100px;" onclick="OpenUploadFile()" />
                        <asp:HiddenField runat="server" ID="hide_ImgPath" />
                    </td>
                </tr>

                <tr>
                    <td class="alignright">简介：</td>
                    <td>
                        <textarea runat="server" id="txtSummay"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="alignright">内容：</td>
                    <td>
                        <!-- 加载编辑器的容器 -->
                        <script id="editor" style="width: 800px; height: 450px; margin: 2px;" name="content" type="text/plain">
                        </script>
                        <!--隐藏控件为编辑器赋值用-->
                        <asp:HiddenField ID="hide_Content" Value="" runat="server" />
                    </td>
                </tr>

                <%--<tr>
                    <td></td>
                    <td class="btnbox">
                        <asp:Button Text="确定保存" runat="server" ID="btnSave" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        <a class="btn btn-warning" onclick="CloseWindow()">关闭</a>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" />
                    </td>
                </tr>--%>
            </table>
            <div class="boxline"></div>
            <div class="btnbox2">
                <asp:Button Text="确定保存" runat="server" ID="btnSave" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <a class="btn btn-warning" onclick="CloseWindow()">关闭</a>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
            </div>
        </div>
    </form>

</body>
</html>
