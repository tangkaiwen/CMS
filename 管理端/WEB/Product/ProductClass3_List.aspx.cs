﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UICommon;

namespace WEB.Product
{
    public partial class ProductClass3_List : UICommon.BasePage_PM
    {
        public int PageSize = 15;
        public int PageIndex
        {
            get
            {
                int page = UICommon.Util.ConvertToInt32(Request["page"]);
                return page > 0 ? page : 1;
            }
        }
        public int TotalCount = 0;
        public string KeyWords
        {
            get
            {
                return UICommon.Util.ConvertToString(Request["keywords"]).Trim();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 删除

        [WebMethod]
        public static object DoDelete(string jsonlist)
        {
            //检测是否登录
            List<int> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(jsonlist);
            int index = 0;
            foreach (int item in list)
            {
                int row_Del = DAL.ProductClass2DAL.Delete_1(item);
                if (row_Del > 0)
                {
                    index++;
                }
            }
            ReturnCode code = ReturnCode.error;
            string msg = "删除失败";
            object data = "";
            if (index > 0)
            {
                code = ReturnCode.success;
                msg = "删除成功,影响行数(" + index;
            }
            object obj = UICommon.ResponseData.GetResponseData(code, msg, data);
            return obj;
        }

        #endregion

        #region 绑定数据

        private void BindData()
        {
            System.Text.StringBuilder sqlWhere = new System.Text.StringBuilder();
            sqlWhere.Append(" UserID=" + userInfo.ID);
            if (!string.IsNullOrEmpty(KeyWords))
            {
                sqlWhere.Append(" AND Title Like '%" + KeyWords + "%'");
            }
            TotalCount = DAL.ProductClass3DAL.GetRecordCount(sqlWhere.ToString());
            List<Model.ProductClass3Entity> productList = DAL.ProductClass3DAL.GetPageList<Model.ProductClass3Entity>(PageIndex, PageSize, "*", sqlWhere.ToString());
            gv_List.DataSource = productList;
            gv_List.DataBind();
        }

        #endregion

        #region 处理数据
        protected void gv_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string ClassName = string.Empty;
                Literal ltProductClass1_ID = e.Row.FindControl("ltProductClass1_ID") as Literal;
                if (ltProductClass1_ID != null)
                {
                    int ProductClass1_ID = Util.ConvertToInt32(ltProductClass1_ID.Text);
                    ClassName += DAL.ProductClass1DAL.Get_99(ProductClass1_ID, "Title").Title;
                }
                Literal ltProductClass2_ID = e.Row.FindControl("ltProductClass2_ID") as Literal;
                if (ltProductClass2_ID != null)
                {
                    int ProductClass2_ID = Util.ConvertToInt32(ltProductClass2_ID.Text);
                    ClassName += ">" + DAL.ProductClass2DAL.Get_99(ProductClass2_ID, "Title").Title;
                }
                Literal ltClassName = e.Row.FindControl("ltClassName") as Literal;
                ltClassName.Text = ClassName;
            }
            catch { }
        }

        #endregion


    }
}