﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineMessage_Detail.aspx.cs" Inherits="WEB.Other.OnlineMessage_Detail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>在线留言详细信息</title>
    <link href="/css/edit.css" rel="stylesheet" />
    <script src="/js/jquery-1.8.3.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/common.js?v=1"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="clearfix ed-title">
                <h3>在线留言详细信息
                </h3>
                <div class="close">
                    <a onclick="CloseWindow(true)">
                        <img src="/Images/close.gif" />
                    </a>
                </div>
            </div>
            <table class="ed-table">
                <tr>
                    <td class="alignright">标题：</td>
                    <td>
                        <%=entity.Title %>
                    </td>
                </tr>
                <tr>
                    <td class="alignright">联系人：</td>
                    <td>
                        <%=entity.RealName %>
                    </td>
                </tr>
                <%if (!string.IsNullOrEmpty(entity.Email))
                  {
                %>
                <tr>
                    <td class="alignright">邮箱：</td>
                    <td><%=entity.Email%></td>
                </tr>
                <%
                  } %>
                <%if (!string.IsNullOrEmpty(entity.QQ))
                  {
                %>
                <tr>
                    <td class="alignright">QQ：</td>
                    <td><%=entity.QQ%></td>
                </tr>
                <%
                  } %>
                <%if (!string.IsNullOrEmpty(entity.Address))
                  {
                %>
                <tr>
                    <td class="alignright">联系地址：</td>
                    <td><%=entity.Address%></td>
                </tr>
                <%
                  } %>
                <tr>
                    <td class="alignright">IP：</td>
                    <td><%=entity.IP  %></td>
                </tr>
                <tr>
                    <td class="alignright">提交时间：</td>
                    <td><%=entity.CreateTS.ToString("yyyy-MM-dd HH:mm")%></td>
                </tr>
                <tr>
                    <td class="alignright">内容：</td>
                    <td><%=entity.TxtContent%></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
