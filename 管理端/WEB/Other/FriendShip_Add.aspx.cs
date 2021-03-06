﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.Other
{
    public partial class FriendShip_Add : UICommon.BasePage_PM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int maxOrder = DAL.FriendShipDAL.GetSingle("MAX(OrderNum)");
                txtOrderNum.Value = UICommon.Util.ConvertToString(maxOrder + 1);
                txtUrl.Value = "http://";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string title = txtTitle.Value;
                string url = txtUrl.Value.Trim();
                int OrderNum = UICommon.Util.ConvertToInt32(txtOrderNum.Value);
                SqlParameter[] pramsAdd =
                    {
                        DAL.DALUtil.MakeInParam("@Title",System.Data.SqlDbType.NVarChar,100,title),
                        DAL.DALUtil.MakeInParam("@Url",System.Data.SqlDbType.NVarChar,250,url),
                        DAL.DALUtil.MakeInParam("@UserID",System.Data.SqlDbType.Int,4,userInfo.ID),
                        DAL.DALUtil.MakeInParam("@OrderNum",System.Data.SqlDbType.Int,4,OrderNum),
                        DAL.DALUtil.MakeInParam("@CreateTS",System.Data.SqlDbType.DateTime,8,DateTime.Now), 
                    };
                int row_Add = DAL.FriendShipDAL.Add(pramsAdd);
                if (row_Add > 0)
                {
                    ltMsg.Visible = true;
                    ltMsg.Text = title + ",保存成功！";
                    txtTitle.Value = string.Empty;
                    txtOrderNum.Value = UICommon.Util.ConvertToString(OrderNum + 1);
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