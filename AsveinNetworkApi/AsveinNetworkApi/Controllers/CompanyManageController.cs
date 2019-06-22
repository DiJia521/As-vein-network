using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using Log;
using Microsoft.AspNetCore.Cors;

namespace AsveinNetworkApi.Controllers
{
    [EnableCors("AllowSameDomain")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyManageController : ControllerBase
    {
        CompanyManageBll bll = new CompanyManageBll();
        /// <summary>
        /// 公司招聘信息添加
        /// </summary>
        /// <param name="company"></param>
        /// 
        ///<returns></returns>

        [HttpPost]
        public int Post(CompanyManage company)
        {
            int result = 0;
            if (company != null)
            {
                result = bll.AddCompany(company);
            }
            else
            {
                //打印到日志
                Logger.Info("招聘发布添加对象为空");
            }
            return result;
        }

        /// <summary>
        /// 职位详情
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetJobMessage/{name}")]
        public List<CompanyManage> GetJobMessage(string name)
        {
            return bll.GetJobMessage(name);
        }

        [HttpGet("{address}/{jobname}")]
        //地点地点模糊查询
        public List<CompanyManage> GetNearAvai(string address, string jobname)
        {
            return bll.GetNearAvai(address, jobname);
        }

        [HttpGet("GetJobList")]
        //查询所有职位信息
        public List<CompanyManage> GetJobList()
        {
            return bll.GetJobList();
        }
    }
}