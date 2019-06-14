using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using AsveinNetworkMvc.Servies;
namespace AsveinNetworkMvc.Controllers
{
    public class AsveinNetworkController : Controller
    {
        private readonly IRepository<AsveinNetwork> _repository;

        public AsveinNetworkController(IRepository<AsveinNetwork> repository)
        {
            _repository = repository;
        }           
        public IActionResult Index()
        {
            var list = _repository.GetAll();
            return View(list);
        }
    }
}