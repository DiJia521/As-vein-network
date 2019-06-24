using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsveinNetworkMvc.Models
{
    public class Resumes
    {
        public int R_Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "不能为空")]
        public string R_Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄")]
        [Required(ErrorMessage = "年龄不能为空")]
        public int R_Age { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Display(Name = "电话")]
        [Required(ErrorMessage = "电话不能为空")]
        public string R_Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [Display(Name = "住址")]
        [Required(ErrorMessage = "住址不能为空")]
        public string R_Address { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "邮箱不能为空")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "请输入正确的邮箱")]
        public string R_Email { get; set; }
        /// <summary>
        /// 经验()年
        /// </summary>
        [Display(Name = "经验")]
        [Required(ErrorMessage = "经验不能为空")]
        public int R_Experience { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        [Display(Name = "照片")]
        [Required(ErrorMessage = "照片不能为空")]
        public string R_Picture { get; set; }
        /// <summary>
        /// 从事职业
        /// </summary>
        [Display(Name = "从事职业")]
        [Required(ErrorMessage = "从事职业不能为空")]
        public string R_Occupation { get; set; }
        /// <summary>
        /// 期望薪资
        /// </summary>
        [Display(Name = "期望薪资")]
        [Required(ErrorMessage = "期望薪资不能为空")]
        public string R_Salary { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        [Display(Name = "学校名称")]
        [Required(ErrorMessage = "学校名称不能为空")]
        public string R_School { get; set; }
        /// <summary>
        /// 就读时间
        /// </summary>
        [Display(Name = "就读时间")]
        [Required(ErrorMessage = "就读时间不能为空")]
        public string R_Studyingtime { get; set; }
        /// <summary>
        /// 所学专业
        /// </summary>
        [Display(Name = "所学专业")]
        [Required(ErrorMessage = "所学专业不能为空")]
        public string R_Major { get; set; }
        /// <summary>
        /// 学历学位
        /// </summary>
        [Display(Name = "学历学位")]
        [Required(ErrorMessage = "学历学位不能为空")]
        public string R_Degree { get; set; }
        /// <summary>
        /// 工作经历
        /// </summary>
        [Display(Name = "工作经历")]
        [Required(ErrorMessage = "工作经历不能为空")]
        public string R_WorkExperience { get; set; }
        /// <summary>
        /// 自我评价
        /// </summary>
        [Display(Name = "自我评价")]
        [Required(ErrorMessage = "自我评价不能为空")]
        public string R_Selfevaluation { get; set; }
    }
}
