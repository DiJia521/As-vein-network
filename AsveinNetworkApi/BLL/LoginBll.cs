﻿using System;
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

        //判断权限
        public int GetLogins(string name)
        {
            return dal.GetLogins(name);
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

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Czmm(string pwd, string name)
        {
            return dal.Czmm(pwd, name);
        }
    }
}
