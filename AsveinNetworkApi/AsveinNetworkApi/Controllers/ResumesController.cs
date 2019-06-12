using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        ResumesBll bll = new ResumesBll();
        //显示
        public List<Resumes> GetResumes()
        {
            return bll.GetResumes();
        }
    }
}