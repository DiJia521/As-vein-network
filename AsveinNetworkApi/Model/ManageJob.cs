using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ManageJob
    {
        public int M_Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string R_Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string R_Phone { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int R_Age { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string R_Address { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string C_CompanyName { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string C_CompanyAddress { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string C_AvailablePositions { get; set; }
        /// <summary>
        /// 期望薪资
        /// </summary>
        public string C_TypeLabor { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public int M_Pass { get; set; }
    }
}
