using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserLogin
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int U_Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string U_Name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string U_Pwd { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public int U_Impower { get; set; }
    }
}
