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
        public List<Resumes> GetResumes()
        {
            return dal.GetResumes();
        }
    }
}
