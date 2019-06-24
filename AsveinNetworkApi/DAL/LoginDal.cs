using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Log;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace DAL
{
    public class LoginDal
    {
        //用户名重复判断
        public bool GetUsers(string name)
        {
            List<UserLogin> list = null;
            var result = false;
            try
            {
                string str = "select * from UserLogin where U_Name = @U_Name";
                var args = new DynamicParameters();
                args.Add("@U_Name", name);

                list = DapperHelper<UserLogin>.Query(str, args);
                if (list.Count != 0)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return result;
        }

        //判断权限
        public int GetLogins(string name)
        {
            List<UserLogin> list = null;
            int result = 0;
            try
            {
                string str = "select U_Impower from UserLogin where U_Name = @U_Name";
                var args = new DynamicParameters();
                args.Add("@U_Name", name);

                list = DapperHelper<UserLogin>.Query(str, args);
                result = list[0].U_Impower;
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return result;
        }


        /// <summary>
        /// 根据用户名，密码登录
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public List<UserLogin> GetLogin(string name, string pwd)
        {
            List<UserLogin> list = null;

            try
            {
                string str = "select * from UserLogin where U_Name = @U_Name and U_Pwd = @U_Pwd ";
                var args = new DynamicParameters();
                args.Add("@U_Name", name);
                args.Add("@U_Pwd", pwd);

                list = DapperHelper<UserLogin>.Query(str, args);
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return list;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Register(UserLogin user)
        {
            int result = 0;
            try
            {
                string str = "insert into UserLogin values (@U_Name,@U_Pwd,@U_Impower)";
                var args = new DynamicParameters();
                args.Add("@U_Name", user.U_Name);
                args.Add("@U_Pwd", user.U_Pwd);
                args.Add("@U_Impower", user.U_Impower);

                result = DapperHelper<UserLogin>.Execute(str, args);
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return result;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="pwd">新密码</param>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public int Czmm(string pwd,string name)
        {
            int result = 0;
            try
            {
                string str = "update UserLogin set U_Pwd = @U_Pwd where U_Name = @U_Name ";
                result = DapperHelper<UserLogin>.Execute(str, new { U_Pwd = pwd, U_Name = name });
            }
            catch (Exception e)
            {
                Logger.Error(e.TargetSite.ToString());
            }

            return result;
        }
    }
}
