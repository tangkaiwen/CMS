﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UICommon
{
    public class Util
    {
        public static int ConvertToInt32(object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    int Num = 0;
                    Int32.TryParse(o.ToString(), out Num);
                    return Num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }

        public static decimal ConvertToDecimal(object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    decimal Num = 0;
                    decimal.TryParse(o.ToString().Trim(), out Num);
                    return Num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// 转换时间
        /// </summary>
        /// <param name="o"></param>
        /// <param name="isNull">错误时是否返回空，否则返回当前时间</param>
        /// <returns></returns>
        public static DateTime? ConvertToDateTime(object o, bool isNull = true)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    DateTime time = DateTime.Now;
                    DateTime.TryParse(o.ToString(), out time);
                    return time;
                }
                else
                {
                    if (!isNull)
                    {
                        return DateTime.Now;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch
            {
                if (!isNull)
                {
                    return DateTime.Now;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string ConvertToString(object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    return o.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        public static bool IsNull(object o)
        {
            try
            {
                string str = ConvertToString(o);
                return string.IsNullOrEmpty(str);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region 防止后退
        /// <summary>
        /// 防止后退
        /// </summary>
        public static void No_Back()
        {
            System.Web.HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            System.Web.HttpContext.Current.Response.CacheControl = "no-cache";//IE
            System.Web.HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            System.Web.HttpContext.Current.Response.Expires = 0;
            System.Web.HttpContext.Current.Response.Buffer = true;
        }
        #endregion

        private static int _seed = int.Parse(DateTime.Now.Ticks.ToString().Substring(10));
        private static int seed { get { return _seed; } set { _seed = value; } }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="RangeString">字符串范围，如："0123456789ABCDEF"</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string GetRandString(string RangeString, int len)
        {
            char[] _a = RangeString.ToCharArray();

            string VNum = "";
            seed++;
            Random rand = new Random(seed);
            for (int i = 0; i < len; i++)
            {
                VNum += _a[rand.Next(_a.Length - 1)];
            }
            return VNum;
        }

        /// <summary>
        /// 获取随机数字
        /// </summary>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string GetRandNumber(int len)
        {
            return GetRandString("0123456789", len);
        }



    }
}
