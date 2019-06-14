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
    }
}
