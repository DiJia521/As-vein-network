using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsveinNetworkMvc.Models
{
    public class UserLogin
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name ="用户ID")]
        public int U_Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name ="用户名")]
        [RegularExpression(@"^1(?:3\d|4[4-9]|5[0-35-9]|6[67]|7[013-8]|8\d|9\d)\d{8}$", ErrorMessage = "请输入正确的手机号码")]
        public string U_Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Display(Name ="用户密码")]
        [Required(ErrorMessage ="不能为空")]
        public string U_Pwd { get; set; }


        /// <summary>
        /// 用户权限
        /// </summary>
        [Display(Name ="用户权限")]
        public int U_Impower { get; set; }
    }
}
