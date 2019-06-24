using System;
using System.Collections.Generic;
using System.Text;
using Log;
using Model;

namespace DAL
{

    public class CompanyManageDal
    {

        /// <summary>
        /// 公司发布招聘添加
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddCompany(CompanyManage company)
        {
            int result = 0;
            try
            {
                //字符串添加
                string str = "insert into  CompanyManage  values(@C_CheckIndustry,@C_AvailablePositions,@C_TypeLabor,@C_NearEstoffice,@C_JobRequirements,@C_Name,@C_CompanyPhone,@C_EmailAddress,@C_CompanyName)";
                //调用
                result = DapperHelper<CompanyManage>.Execute(str, new
                {
                    C_CheckIndustry = company.C_CheckIndustry,
                    C_AvailablePositions = company.C_AvailablePositions,
                    C_TypeLabor = company.C_TypeLabor,
                    C_NearEstoffice = company.C_NearEstoffice,
                    C_JobRequirements = company.C_JobRequirements,
                    C_Name = company.C_Name,
                    C_CompanyPhone = company.C_CompanyPhone,
                    C_EmailAddress = company.C_EmailAddress,
                    C_CompanyName = company.C_CompanyName
                });
            }
            catch (Exception e)
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

        //地点职位模糊查询
        public List<CompanyManage> GetNearAvai(string C_NearEstoffice, string C_AvailablePositions)
        {
            List<CompanyManage> list = null;
            try
            {
                //地点条件查询                
                string sql = "select * from CompanyManage ";
                if (!string.IsNullOrEmpty(C_NearEstoffice))
                {
                    sql += " where C_NearEstoffice like '%" + C_NearEstoffice + "%' ";
                }
                //职位条件查询                
                if (!string.IsNullOrEmpty(C_AvailablePositions))
                {
                    sql += " or  C_AvailablePositions like '%" + C_AvailablePositions + "%' ";
                }
                list = DapperHelper<CompanyManage>.Query(sql, new { C_NearEstoffice = C_NearEstoffice, C_AvailablePositions = C_AvailablePositions });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }
            return list;
        }

        //查询所有职位信息
        public List<CompanyManage> GetJobList()
        {
            string str = "select C_AvailablePositions,C_NearEstoffice,C_TypeLabor from CompanyManage ";
            var list = DapperHelper<CompanyManage>.Query(str, null);
            return list;
        }
        public List<ManageJob> GetManege(int selectId)
        {
            List<ManageJob> list = null;
            try
            {
                string str = "select *from ManageJob where M_Pass=@selectId";
                list = DapperHelper<ManageJob>.Query(str, new { selectId = selectId });
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            return list;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns></returns>
        public int PutPass(ManageJob manageJob)
        {
            int result = 0;
            try
            {
                //字符串修改
                string str = "update  ManageJob  set M_Pass=1 where M_Id=@p_id";
                //调用
                result = DapperHelper<CompanyManage>.Execute(str, new { p_id = manageJob.M_Id });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="d_id"></param>
        /// <returns></returns>
        public int DeleteMa(int d_id)
        {
            int result = 0;
            try
            {
                //字符串修改
                string str = "delete from ManageJob where M_Id=@d_id";
                //调用
                result = DapperHelper<CompanyManage>.Execute(str, new { d_id = d_id });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }
            return result;
        }
    }
}
