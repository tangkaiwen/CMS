﻿
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Login : System.Web.UI.Page
    {
        private string LoginSource2 = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //记录UrlReferrer
                if (Request.UrlReferrer != null)
                {
                    string LoginSource = Request.UrlReferrer.OriginalString;
                    hideLoginSource.Value = LoginSource2 = LoginSource;
                }

            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Value.Trim();
            string pwd = txtPwd.Value.Trim();
            string yzm = txtYzm.Value.Trim();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd) && !string.IsNullOrEmpty(yzm))
            {

                string ValidateCode = UICommon.Util.ConvertToString(Session["ValidateCode"]);
                if (yzm == ValidateCode)
                {
                    Session["ValidateCodeError"] = 0;
                    Session["ValidateCodeLength"] = 2;
                    string password = UICommon.SecurityHelper.MD5Encrypt(pwd);
                    int result = DAL.AdminAccountDAL.Login(name, password);
                    if (result == 1)
                    {
                        UICommon.ScriptHelper.Alert("账号不存在！");
                    }
                    else if (result == 2)
                    {
                        UICommon.ScriptHelper.Alert("密码不正确！");
                    }
                    else if (result == 8)
                    {
                        int userID = DAL.AdminAccountDAL.GetUserID(name);
                        UserInfoEntity userInfo = DAL.UserInfoDAL.Get_99(userID, "id,TC_Name,UserName,LastLoginTime");
                        userInfo.LoginName = name;
                        Session["UserInfo"] = userInfo;
                        LoginLog(userInfo);
                        UICommon.ScriptHelper.ShowAndRedirect("登录成功！", "Index.aspx");
                    }
                    else
                    {
                        UICommon.ScriptHelper.Alert("登录异常，请刷新重试！");
                    }
                }
                else
                {
                    int ValidateCodeError = UICommon.Util.ConvertToInt32(Session["ValidateCodeError"]);
                    Session["ValidateCodeError"] = ValidateCodeError + 1;
                    if (ValidateCodeError >= 5)
                    {
                        Session["ValidateCodeLength"] = 5;//验证码错误4次
                    }
                    UICommon.ScriptHelper.Alert("验证码不正确！");
                }
            }
            else
            {
                UICommon.ScriptHelper.Alert("请填写完整的登录信息！");

            }
        }

        #region 登录日志
        private void LoginLog(UserInfoEntity userInfo)
        {
            try
            {
                string IP = UICommon.Util.GetIP();
                string LoginUrl = Request.Url.OriginalString;
                string LoginSource = hideLoginSource.Value;
                string TxtContent = "用户【" + userInfo.UserName + "】,登录网站管理后台。";
                DAL.UserLoginLogDAL.Add(userInfo.ID, userInfo.UserName, IP, LoginUrl, LoginSource, TxtContent);
            }
            catch (Exception ex)
            {
                LogCommon.Logs.write("LoginLog", ex.ToString());
            }
        }

        #endregion
    }
}