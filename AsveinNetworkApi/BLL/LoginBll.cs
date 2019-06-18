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

        public bool GetUsers(string name)
        {
            return dal.GetUsers(name);
        }

        /// <summary>
        /// 根据用户名，密码登录
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public List<UserLogin> GetLogin(string name, string pwd)
        {
            return dal.GetLogin(name, pwd);
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
