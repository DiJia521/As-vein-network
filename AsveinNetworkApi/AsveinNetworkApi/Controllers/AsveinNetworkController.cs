using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
using System.Net.Http;

namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsveinNetworkController : ControllerBase
    {        
        AsvienNetworkBll bll = new AsvienNetworkBll();
        // GET: api/values
        [HttpGet]
        public List<AsveinNetwork> GetAsvein()
        {
            return bll.GetAsvein();
        }       
    }
}