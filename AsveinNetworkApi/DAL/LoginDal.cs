﻿using Model;
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
                Logger.Error("查询错误");
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
                Logger.Error("登录失败");
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
                Logger.Error("注册失败");
            }

            return result;
        }
    }
}
