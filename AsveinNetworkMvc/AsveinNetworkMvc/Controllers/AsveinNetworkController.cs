using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AsveinNetworkMvc.Controllers
{
    public class AsveinNetworkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}