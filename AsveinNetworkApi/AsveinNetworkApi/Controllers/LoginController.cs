using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Orange.Jiuhemu.Utility;

namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSameDomain")]
    public class LoginController : ControllerBase
    {
        LoginBll bll = new LoginBll();

        [HttpGet]
        public ActionResult<string> Get(string UserName,string pwd)
        {
            return "value";
        }
        [HttpPost]
        public int Post(UserLogin user)
        {
            return 1;
        }
        /// <summary>
        /// 根据用户名，密码登录
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet("{userName,pwd}",Name ="Get")]
        public List<UserLogin> GetLogin(string userName, string pwd)
        {
            return bll.GetLogin(userName, pwd);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //Post api/Login
        [HttpPost("PostRegister")]
        public int PostRegister([FromBody] UserLogin user)
        {
            return bll.Register(user);
        }
    }
}