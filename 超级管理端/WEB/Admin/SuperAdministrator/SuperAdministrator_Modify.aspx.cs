﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Admin.SuperAdministrator
{
    public partial class SuperAdministrator_Modify : UICommon.BasePage_Admin
    {
        public int ID
        {
            get
            {
                return UICommon.Util.ConvertToInt32(Request["ID"]);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.SuperAdministratorEntity entity = DAL.SuperAdministratorDAL.Get_99(ID, "*");
                txtLoginName.Text = entity.LoginName;
                txtNickName.Value = entity.NickName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string NickName = txtNickName.Value.Trim();
                string password = txtPassword.Value.Trim();
                string md5Password = UICommon.SecurityHelper.MD5Encrypt(password);
                List<SqlParameter> pramsModifyList = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(password))
                {
                    pramsModifyList.Add(DAL.DALUtil.MakeInParam("@Password", System.Data.SqlDbType.NVarChar, 200, md5Password));
                }
                pramsModifyList.Add(DAL.DALUtil.MakeInParam("@NickName", System.Data.SqlDbType.NVarChar, 200, NickName));

                int row_Mod = DAL.SuperAdministratorDAL.Modify(pramsModifyList.ToArray(), ID);
                if (row_Mod > 0)
                {
                    UICommon.ScriptHelper.Alert("修改成功！");
                }
                else
                {
                    UICommon.ScriptHelper.Alert("保存失败");
                }
            }
            catch (Exception ex)
            {
                UICommon.ScriptHelper.Alert("保存失败," + ex.Message);
            }
        }

    }
}