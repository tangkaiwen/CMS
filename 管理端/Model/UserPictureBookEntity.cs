﻿using System;
using System.Collections.Generic;
using System.Text;
namespace Model
{
    /// <summary>
    /// 实体：UserPictureBookEntity
    /// 创建工具 :TCode
    /// 生成时间:2016-12-10 14:47
    /// </summary>
    public class UserPictureBookEntity
    {
        #region 原始字段

        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int OrderNum { get; set; }
        public DateTime CreateTS { get; set; }
        public string Remark { get; set; }

        #endregion

    }
}

