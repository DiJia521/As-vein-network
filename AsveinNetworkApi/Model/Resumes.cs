using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Resumes
    {
        public int R_Id { get; set; }  //id
        public string R_Name { get; set; } //姓名
        public int R_Age { get; set; }  //年龄
        public string R_Phone { get; set; }  //电话
        public string R_Address { get; set; }  //住址
        public string R_Email { get; set; } //邮箱
        public int R_Experience { get; set; }  //经验()年
        public string R_Picture { get; set; } //照片
        public string R_Occupation { get; set; } //从事职业
        public string R_Salary { get; set; } //期望薪资
        public string R_School { get; set; } //学校名称
        public string R_Studyingtime { get; set; } //就读时间
        public string R_Major { get; set; } //所学专业
        public string R_Degree { get; set; } //学历学位
        public string R_WorkExperience { get; set; } //工作经历
        public string R_Selfevaluation { get; set; } //自我评价
        
    }
}
