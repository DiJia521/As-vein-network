using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Log;

namespace DAL
{

    public class CompanyDal
    {
        /// <summary>
        /// 公司显示显示主界面
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompany(string phone)
        {
            List<Company> str = null;
            try
            {
                string sql = string.Format("select * from Company where CompanyPhone = @CompanyPhone");
                str = DapperHelper<Company>.Query(sql, new { CompanyPhone = phone });
            }
            catch (Exception e)
            {
                Logger.Error("404");
            }
            return str;
        }

        /// <summary>
        /// 公司界面添加
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int InsertCompany(Company com)
        {
            int result = 0;
            try
            {
                //字符串添加
                string str = "insert into  Company  values(@CName,@CNameNature,@Cnumber,@CompanyIndustry,@CompanyProfile,@Companyposition,@CompanyPhone)";
                //调用
                result = DapperHelper<Company>.Execute(str, new
                {
                    CName = com.CName,
                    CNameNature = com.CNameNature,
                    Cnumber = com.Cnumber,
                    CompanyIndustry = com.CompanyIndustry,
                    CompanyProfile = com.CompanyProfile,
                    Companyposition = com.Companyposition,
                    CompanyPhone = com.CompanyPhone
                });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }
            return result;
        }
    }
}
