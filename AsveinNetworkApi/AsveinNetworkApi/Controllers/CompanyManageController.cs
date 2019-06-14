using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using Log;

namespace AsveinNetworkApi.Controllers
{
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
            if(company!=null)
            {
                result=  bll.AddCompany(company);
            }
            else
            {
                //打印到日志
                Logger.Info("招聘发布添加对象为空");
            }
            return result;
        }
    }
}