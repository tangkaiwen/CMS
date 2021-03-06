﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Model;
namespace DAL
{
    /// <summary>
    /// Create By Tool :TCode
    /// Create Time:2016-11-19 02:52
    /// </summary>
    public class UserInfoDAL
    {
        /// <summary>
        ///表名
        /// <summary>
        private static string TableName = "UserInfo";

        #region 新增
        /// <summary>
        ///新增
        /// <summary>
        /// <param name="pramsAdd">参数</param>
        /// <returns>成功返回自增ID</returns>
        public static int Add(SqlParameter[] pramsAdd)
        {
            return DBCommon.DBHelper.Add(DALUtil.ConnString, TableName, pramsAdd);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pramsModify">修改参数集合</param>
        /// <param name="pramsWhere">条件集合</param>
        /// <returns>成功返回影响行数,失败返回0</returns>
        public static int Add(SqlParameter[] pramsModify, SqlParameter[] pramsWhere)
        {
            return DBCommon.DBHelper.Modify(DALUtil.ConnString, TableName, pramsModify, pramsWhere);
        }
        #endregion

        #region 获取一条数据
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <typeparam name="T">返回实体</typeparam>
        /// <param name="SelectIF">需要查询的字段</param>
        /// <param name="pramsWhere">条件集合</param>
        public static T Get1<T>(string SelectIF, SqlParameter[] pramsWhere)
        {
            DataTable dt = DBCommon.DBHelper.GetDataTable1(DALUtil.ConnString, TableName, SelectIF, pramsWhere);
            return DALUtil.ConvertDataTableToEntity<T>(dt);
        }
        #endregion

        #region 获取集合
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T">集合实体</typeparam>
        /// <param name="SelectIF">需要查询的字段</param>
        /// <param name="pramsWhere">条件集合</param>
        /// <param name="OrderName">排序无需带Order by</param>
        public static List<T> GetList<T>(string SelectIF, SqlParameter[] pramsWhere, string OrderName = "")
        {
            DataTable dt = DBCommon.DBHelper.GetDataTable2(DALUtil.ConnString, TableName, SelectIF, pramsWhere, OrderName);
            return DALUtil.ConvertDataTableToEntityList<T>(dt);
        }
        #endregion

        #region 分页获取数据
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">数量</param>
        /// <param name="SelectIF">查询字段</param>
        /// <param name="pramsWhere">条件</param>
        /// <param name="OrderName">排序无需带Order by</param>
        public static List<T> GetPageList<T>(int PageIndex, int PageSize, string SelectIF, SqlParameter[] pramsWhere, string OrderName = "")
        {
            DataTable dt = DBCommon.DBHelper.GetDataTablePage(DALUtil.ConnString, TableName, SelectIF, PageIndex, PageSize, pramsWhere, OrderName);
            return DALUtil.ConvertDataTableToEntityList<T>(dt);
        }

        /// <summary>
        /// 获取数据总数量
        /// </summary>
        /// <param name="pramsWhere">条件</param>
        public static int GetRecordCount(SqlParameter[] pramsWhere)
        {
            string SelectIF = " count(1) ";
            object obj = DBCommon.DBHelper.GetSingle(DALUtil.ConnString, TableName, SelectIF, pramsWhere);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return DALUtil.ConvertToInt32(obj);
            }
        }
        #endregion

        #region 获取自定义参数数据
        /// <summary>
        /// 获取自定义参数数据
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="SelectIF">查询字段</param>
        public static UserInfoEntity Get_99(int ID, string SelectIF)
        {
            try
            {
                //参数Where条件
                SqlParameter[] pramsWhere =
				{
					DALUtil.MakeInParam("@ID", SqlDbType.Int, 4, ID)
				};
                return Get1<UserInfoEntity>(SelectIF, pramsWhere);
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pramsModify">修改参数集合</param>
        /// <param name="id">ID</param>
        /// <returns>成功返回影响行数,失败返回0</returns>
        public static int Modify(SqlParameter[] pramsModify, int id)
        {
            SqlParameter[] pramsWhere =
			{
				DALUtil.MakeInParam("@ID",SqlDbType.Int,4,id)
			};
            return DBCommon.DBHelper.Modify(DALUtil.ConnString, TableName, pramsModify, pramsWhere);
        }
		

    }
}

