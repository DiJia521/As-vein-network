using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class LoginDal
    {
        public List<UserLogin> GetUsers()
        {
            string str = "select * from UserLogin ";
            return DapperHelper<UserLogin>.Query(str, null);
        }

        public UserLogin GetLogin(string Name, string pwd)
        {
            string str = "select * from UserLogin where UserName = @UserName and UserPwd = @UserPwd ";
            return DapperHelper<UserLogin>.QuerySingle(str, new { UserName = Name, UserPwd = pwd });
        }
    }
}
