using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Log;

namespace DAL
{
    public class ResumesDal
    {
        /// <summary>
        /// 显示简历信息
        /// </summary>
        /// <returns></returns>
        public List<Resumes> GetResumes()
        {
            List<Resumes> str = null;
            try
            {
                string sql = string.Format("select * from Resumes");
                str = DapperHelper<Resumes>.Query(sql, null);
            }
            catch (Exception e)
            {
                Logger.Error("404");
            }

            return str;
        }
        /// <summary>
        /// 添加数据信息 
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public int AddResumes(Resumes res)
        {
            string str = "insert into Resumes values (@R_Name,@R_Age,@R_Phone,@R_Address,@R_Email,@R_Experience,@R_Picture,@R_Occupation,@R_Salary,@R_School,@R_Studyingtime,@R_Major,@R_Degree,@R_WorkExperience,@R_Selfevaluation)";
            return DapperHelper<Resumes>.Execute(str, new
            {
                R_Name = res.R_Name,
                R_Age = res.R_Age,
                R_Phone = res.R_Phone,
                R_Address = res.R_Address,
                R_Email = res.R_Email,
                R_Experience = res.R_Experience,
                R_Picture = res.R_Picture,
                R_Occupation = res.R_Occupation,
                R_Salary = res.R_Salary,
                R_School = res.R_School,
                R_Studyingtime = res.R_Studyingtime,
                R_Major = res.R_Major,
                R_Degree = res.R_Degree,
                R_WorkExperience = res.R_WorkExperience,
                R_Selfevaluation = res.R_Selfevaluation
            });

        }
    }
}
