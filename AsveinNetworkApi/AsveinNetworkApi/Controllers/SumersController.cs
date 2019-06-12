using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumersController : ControllerBase
    {
        public string name { get; set; }
        
    }
}