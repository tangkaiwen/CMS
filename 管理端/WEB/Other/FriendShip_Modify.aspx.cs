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


namespace WEB.Other
{
    public partial class FriendShip_Modify : BasePage_PM
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
                Model.FriendShipEntity entity = FriendShipDAL.Get_99(ID, "*");
                txtTitle.Value = entity.Title;
                txtOrderNum.Value = UICommon.Util.ConvertToString(entity.OrderNum);
                txtUrl.Value = UICommon.Util.ConvertToString(entity.Url);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Value.Trim();
            string url = txtUrl.Value.Trim();
            int OrderNum = UICommon.Util.ConvertToInt32(txtOrderNum.Value.Trim());
            SqlParameter[] pramsModify =
            {
                DAL.DALUtil.MakeInParam("@Title",System.Data.SqlDbType.NVarChar,100,title), 
                DAL.DALUtil.MakeInParam("@OrderNum",System.Data.SqlDbType.Int,4,OrderNum), 
                DAL.DALUtil.MakeInParam("@Url",System.Data.SqlDbType.NVarChar,250,url),
            };
            int row_Add = DAL.FriendShipDAL.Modify(pramsModify, ID);
            if (row_Add > 0)
            {
                ltMsg.Visible = true;
                ltMsg.Text = title + ",修改成功！";
            }
            else
            {
                UICommon.ScriptHelper.Alert("保存失败");
            }
        }
    }
}