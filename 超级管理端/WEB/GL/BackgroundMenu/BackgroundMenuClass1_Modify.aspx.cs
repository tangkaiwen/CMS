﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UICommon;

namespace WEB.GL.BackgroundMenu
{
    public partial class BackgroundMenuClass1_Modify : BasePage_PM
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
                BackgroundMenuClass1Entity entity = DAL.BackgroundMenuClass1DAL.Get_99(ID, "*");
                txtTitle.Value = entity.Title;
                txtOrderNum.Value = UICommon.Util.ConvertToString(entity.OrderNum);
                txtValueNum.Value = UICommon.Util.ConvertToString(entity.ValueNum);
                txtManageUrl.Value = entity.ManageUrl;
                txtDescription.Value = entity.Description;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Value.Trim();
            string ManageUrl = txtManageUrl.Value.Trim();
            string Description = txtDescription.Value.Trim();
            int ValueNum = UICommon.Util.ConvertToInt32(txtValueNum.Value.Trim());
            int OrderNum = UICommon.Util.ConvertToInt32(txtOrderNum.Value.Trim());

            SqlParameter[] pramsModify =
            {
                DAL.DALUtil.MakeInParam("@Title",System.Data.SqlDbType.NVarChar,100,title),   
                DAL.DALUtil.MakeInParam("@OrderNum",System.Data.SqlDbType.Int,4,OrderNum),
                DAL.DALUtil.MakeInParam("@ValueNum",System.Data.SqlDbType.Int,4,ValueNum),
                DAL.DALUtil.MakeInParam("@ManageUrl",System.Data.SqlDbType.NVarChar,500,ManageUrl),
                DAL.DALUtil.MakeInParam("@Description",System.Data.SqlDbType.NVarChar,200,Description),  
            };
            int row_Mod = DAL.BackgroundMenuClass1DAL.Modify(pramsModify, ID);
            if (row_Mod > 0)
            {
                UICommon.ScriptHelper.Alert(title + ",修改成功！");
            }
            else
            {
                UICommon.ScriptHelper.Alert("保存失败");
            }
        }
    }
}