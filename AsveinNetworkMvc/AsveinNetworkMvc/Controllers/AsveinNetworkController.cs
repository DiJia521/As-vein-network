using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
namespace AsveinNetworkMvc.Controllers
{
    public class AsveinNetworkController : Controller
    {
       
        public IActionResult Index()
        {
            string json = Http.GetApiResult("get", "Index", null);
            List<AsveinNetwork> list = JsonConvert.DeserializeObject<List<AsveinNetwork>>(json);
            return View(list);
        }
    }
}