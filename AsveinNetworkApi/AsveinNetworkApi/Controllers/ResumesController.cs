using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
using Microsoft.AspNetCore.Cors;

namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSameDomain")]
    public class ResumesController : ControllerBase
    {
        ResumesBll bll = new ResumesBll();
        /// <summary>
        /// 显示简历信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetResumes/{name}")]
        public List<Resumes> GetResumes(string name)
        {
            return bll.GetResumes(name);
        }

        /// <summary>
        /// 根据电话号码查询个人简历信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet("GetResume/{phone}")]
        public List<Resumes> GetResume(string phone)
        {
            return bll.GetResume(phone);
        }

        /// <summary>
        /// 添加数据信息 
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddResumes(Resumes res)
        {
            return bll.AddResumes(res);

        }

        /// <summary>
        /// 提交简历
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost("AddManageJob")]
        public int AddManageJob([FromBody] ManageJob job)
        {
            return bll.AddManageJob(job);
        }



    }
}