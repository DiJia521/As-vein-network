using System;
using System.Collections.Generic;
using System.Text;
using Log;
using DAL;
using Model;

namespace BLL
{
    public class CompanyManageBll
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

        //地点职位模糊查询
        public List<CompanyManage> GetNearAvai(string C_NearEstoffice, string C_AvailablePositions)
        {
            return dal.GetNearAvai(C_NearEstoffice, C_AvailablePositions);
        }

        //查询所有职位信息
        public List<CompanyManage> GetJobList()
        {
            return dal.GetJobList();
        }
    }
}
