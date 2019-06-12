using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Log;
using Model;

namespace BLL
{
    public class LoginBll
    {
        LoginDal dal = new LoginDal();

        /// <summary>
        /// 根据用户名，密码登录
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public List<UserLogin> GetLogin(string Name, string pwd)
        {
            return dal.GetLogin(Name, pwd);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Register(UserLogin user)
        {
            return dal.Register(user);
        }
    }
}
