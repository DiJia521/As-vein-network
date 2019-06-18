using System;
using System.Collections.Generic;
using System.Text;
using Log;
using Model;

namespace DAL
{

   public  class CompanyManageDal
    {

        /// <summary>
        /// 公司发布招聘添加
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public   int   AddCompany(CompanyManage company)
        {
            int result = 0;
            try
            {
                //字符串添加
                string str = "insert into  CompanyManage  values(@C_CheckIndustry,@C_AvailablePositions,@C_TypeLabor,@C_NearEstoffice,@C_JobRequirements,@C_Name,@C_CompanyPhone,@C_EmailAddress,@C_CompanyName)";
                //调用
                result = DapperHelper<CompanyManage>.Execute(str,new { C_CheckIndustry=company.C_CheckIndustry, C_AvailablePositions=company.C_AvailablePositions, C_TypeLabor=company.C_TypeLabor, C_NearEstoffice=company.C_NearEstoffice,
                    C_JobRequirements=company.C_JobRequirements,C_Name=company.C_Name,C_CompanyPhone=company.C_CompanyPhone,
                    C_EmailAddress=company.C_EmailAddress,
                    C_CompanyName=company.C_CompanyName
                } );
            }
            catch(Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }
            return result;
        }

        /// <summary>
        /// 职位详情
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<CompanyManage> GetJobMessage(string name)
        {
            List<CompanyManage> list = null;
            try
            {
                string str = "select * from CompanyManage where C_AvailablePositions=@C_AvailablePositions ";
                list = DapperHelper<CompanyManage>.Query(str, new { C_AvailablePositions = name });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return list;
        }
    }
}
