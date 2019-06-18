using System;
using System.Collections.Generic;
using System.Text;
using Log;
using DAL;
using Model;

namespace BLL
{
  public  class CompanyManageBll
    {
        CompanyManageDal dal = new CompanyManageDal();
        /// <summary>
        /// 公司发布招聘添加
        /// </summary>
        /// <param name="company">对象</param>
        /// <returns></returns>
        public int AddCompany(CompanyManage company)
        {
            //调用dal层方法
            return dal.AddCompany(company);
        }

        /// <summary>
        /// 职位详情
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<CompanyManage> GetJobMessage(string name)
        {
            return dal.GetJobMessage(name);
        }
    }
}
