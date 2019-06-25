using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsveinNetworkMvc.Models
{
    public class Company
    {
        public int Cid { get; set; }
        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "不能为空")]
        public string CName { get; set; }
        [Display(Name = "性质")]
        [Required(ErrorMessage = "不能为空")]
        public string CNameNature { get; set; }
        [Display(Name = "人数")]
        [Required(ErrorMessage = "不能为空")]
        public int Cnumber { get; set; }
        [Display(Name = "行业")]
        [Required(ErrorMessage = "不能为空")]
        public string CompanyIndustry { get; set; }
        [Display(Name = "简介")]
        [Required(ErrorMessage = "不能为空")]
        public string CompanyProfile { get; set; }
        [Display(Name = "职位")]
        [Required(ErrorMessage = "不能为空")]
        public string Companyposition { get; set; }
        [Display(Name = "人事电话")]
        [Required(ErrorMessage = "不能为空")]
        public string CompanyPhone { get; set; }
    }
}
