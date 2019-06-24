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
        public List<Resumes> GetResumes(string name)
        {
            List<Resumes> str = null;
            try
            {
                string sql = string.Format("select * from Resumes where R_Name = @R_Name");
                str = DapperHelper<Resumes>.Query(sql, new { R_Name = name });
            }
            catch (Exception e)
            {
                Logger.Error("404");
            }            
            return str;
        }

        /// <summary>
        /// 根据电话号码查询个人简历信息
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <returns></returns>
        public List<Resumes> GetResume(string phone)
        {
            List<Resumes> result = null;
            try
            {
                string sql = "select R_Name,R_Phone,R_Age,R_Email,R_Salary from Resumes where R_Phone = @R_Phone ";
                result = DapperHelper<Resumes>.Query(sql, new { R_Phone = phone });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return result;
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

        /// <summary>
        /// 提交简历
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public int AddManageJob(ManageJob job)
        {
            string str = "insert into ManageJob values (@R_Name,@R_Phone,@R_Age,@R_EmailAddress,@C_CompanyName,@C_AvailablePositions,@C_TypeLabor,@M_Pass,@C_CompanyAddress)";
            return DapperHelper<ManageJob>.Execute(str, new
            {
                R_Name = job.R_Name,
                R_Phone = job.R_Phone,
                R_Age = job.R_Age,
                R_EmailAddress = job.R_EmailAddress,
                C_CompanyName = job.C_CompanyName,
                C_AvailablePositions = job.C_AvailablePositions,
                C_TypeLabor = job.C_TypeLabor,
                M_Pass = job.M_Pass,
                C_CompanyAddress = job.C_CompanyAddress,
            });
        }


        /// <summary>
        /// 反添简历信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Resumes SelectResumes(int id)
        {
            var sql = "select * from Resumes where R_Id = @R_Id";
            return DapperHelper<Resumes>.QueryFirst(sql, new { R_Id = id });
        }


        /// <summary>
        /// 修改简历信息
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public int UpdateResumes(Resumes res)
        {
            var rest = "update Resumes set R_Name = @R_Name,R_Age = @R_Age,R_Phone = @R_Phone,R_Address = @R_Address,R_Email = @R_Email,R_Experience = @R_Experience,R_Picture = @R_Picture,R_Occupation = @R_Occupation,R_Salary = @R_Salary,R_School = @R_School,R_Studyingtime = @R_Studyingtime,R_Major = @R_Major,R_Degree = @R_Degree,R_WorkExperience = @R_WorkExperience,R_Selfevaluation = @R_Selfevaluation where R_Id = @R_Id";
            return DapperHelper<Resumes>.Execute(rest, new
            {
                R_Id = res.R_Id,
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
