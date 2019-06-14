using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsveinNetworkMvc.Models
{
    public class CompanyManage
    {
        [Display(Name ="编号")]
        public int Id { get; set; }
        [Display( Name ="选择行业")]
        [Required(ErrorMessage ="不能为空")]
        public string C_CheckIndustry { get; set; }
        [Display(Name = "所要招聘的职位")]
        [Required(ErrorMessage = "不能为空")]
        public string C_AvailablePositions { get; set; }
        [Display(Name = "用工类型")]
        [Required(ErrorMessage = "不能为空")]
        public string C_TypeLabor { get; set; }
        [Display(Name = "最近办事处")]
        [Required(ErrorMessage = "不能为空")]
        public string C_NearEstoffice { get; set; }
        [Display(Name = "职位描述")]
        [Required(ErrorMessage = "不能为空")]
        public string C_JobRequirements { get; set; }
        [Display(Name = "发布人姓名")]
        [Required(ErrorMessage = "不能为空")]
        public string C_Name { get; set; }
        [Display(Name = "公司电话")]
        [Required(ErrorMessage = "不能为空")]
        [RegularExpression(@"^((0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$", ErrorMessage ="请输入正确的电话号码")]
        public string C_CompanyPhone { get; set; }
        [Display(Name = "电子邮件地址")]
        [Required(ErrorMessage = "不能为空")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "请输入正确的邮箱")]
        public string C_EmailAddress { get; set; }
        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "不能为空")]
        public string C_CompanyName { get; set; }
    }
}
