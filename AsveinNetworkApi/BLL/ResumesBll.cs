using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
namespace BLL
{
    public class ResumesBll
    {
        ResumesDal dal = new ResumesDal();
        /// <summary>
        /// 显示简历信息
        /// </summary>
        /// <returns></returns>
        public List<Resumes> GetResumes(string name)
        {
            return dal.GetResumes(name);
        }

        /// <summary>
        /// 根据电话号码查询个人简历信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Resumes> GetResume(string phone)
        {
            return dal.GetResume(phone);
        }

        /// <summary>
        /// 添加数据信息 
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public int AddResumes(Resumes res)
        {
            return dal.AddResumes(res);
        }

        /// <summary>
        /// 提交简历
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public int AddManageJob(ManageJob job)
        {
            return dal.AddManageJob(job);
        }

        /// <summary>
        /// 反添简历信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Resumes SelectResumes(int id)
        {
            return dal.SelectResumes(id);
        }

        /// <summary>
        /// 修改简历信息
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public int UpdateResumes(Resumes res)
        {
            return dal.UpdateResumes(res);
        }

    }
}
