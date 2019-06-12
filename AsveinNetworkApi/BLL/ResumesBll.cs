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
        //显示
        public List<Resumes> GetResumes()
        {
            return dal.GetResumes();
        }
    }
}
