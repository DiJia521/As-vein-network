using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Log;

namespace DAL
{
    public class LoginDal
    {
        public List<UserLogin> GetUsers()
        {
            List<UserLogin> list = null;
            try
            {
                string str = "select * from UserLogin ";
                list = DapperHelper<UserLogin>.Query(str, null);
            }
            catch(Exception e)
            {
                Logger.Error("查询错误");
            }

            return list;
        }

        /// <summary>
        /// 根据用户名，密码登录
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public UserLogin GetLogin(string Name, string pwd)
        {
            UserLogin list = null;

            try
            {
                string str = "select * from UserLogin where U_Name = @U_Name and U_Pwd = @U_Pwd ";
                list = DapperHelper<UserLogin>.QuerySingle(str, new { U_Name = Name, U_Pwd = pwd });
            }
            catch(Exception e)
            {
                Logger.Error("登录出错");
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
                result = DapperHelper<UserLogin>.Execute(str, new { U_Name = user.U_Name, U_Pwd = user.U_Pwd, U_Impower = user.U_Impower });
            }
            catch (Exception e)
            {
                Logger.Error("注册失败");
            }

            return result;
        }
    }
}
