using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
using Log;

namespace BLL
{

    public class CompanyBll
    {
        CompanyDal dal = new CompanyDal();
        /// <summary>
        /// 公司显示显示主界面
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompany(string phone)
        {
            return dal.GetCompany(phone);
        }

        /// <summary>
        /// 公司界面添加
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int InsertCompany(Company com)
        {
            return dal.InsertCompany(com);
        }
    }
}
