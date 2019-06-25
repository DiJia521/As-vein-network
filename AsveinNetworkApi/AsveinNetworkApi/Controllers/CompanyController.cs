using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
using Log;
using log4net;
namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyBll bll = new CompanyBll();
        [HttpGet("GetCompany/{phone}")]
        //查询所有职位信息
        public List<Company> GetCompany(string phone)
        {
            return bll.GetCompany(phone);
        }
        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPost]
        public int InsertCompany(Company com)
        {
            return bll.InsertCompany(com);
        }
    }
}