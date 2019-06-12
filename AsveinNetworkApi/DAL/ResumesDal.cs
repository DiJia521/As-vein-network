﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;

using Log;
namespace DAL
{
    public class ResumesDal
    {
        //显示
        public List<Resumes> GetResumes()
        {
            List<Resumes> list = null;
            try
            {
                string str = string.Format("select * from Resumes");
                list = DapperHelper<Resumes>.Query(str, null);
            }
            catch (Exception e)
            {
                Logger.Error("查询错误");
            }

            return list;
        }
    }
}
