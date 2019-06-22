using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using AsveinNetworkMvc.Models;
using Newtonsoft.Json;
namespace AsveinNetworkMvc.Controllers
{
    public class AsveinNetworkController : Controller
    {
        public string Sender(string method, string path, string content)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage responseMessage = null;
            switch (method)
            {
                case "get": //查询
                    responseMessage = client.GetAsync(path).Result;
                    break;
                case "post": //添加
                    HttpContent httpContent = new StringContent(content);
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    responseMessage = client.PostAsync(path, httpContent).Result;
                    break;
                case "delete": //查询
                    responseMessage = client.DeleteAsync(path).Result;
                    break;
                case "put": //查询
                    HttpContent httpContent1 = new StringContent(content);
                    httpContent1.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    responseMessage = client.PutAsync(path, httpContent1).Result;

                    break;
                default: break;

            }
            if (responseMessage.IsSuccessStatusCode == true)
            {
                string result = responseMessage.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                return "失败";
            }
        }
        [HttpGet]
        //显示
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //关于我们
        public IActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        //搜索界面
        public IActionResult XinJobsearch()
        {
            var result = Sender("get", "api/CompanyManage/GetJobList", null);
            List<CompanyManage> list = JsonConvert.DeserializeObject<List<CompanyManage>>(result);
            return View(list);
        }
        //模糊查询方法
        [HttpPost]
        public IActionResult XinJobsearch(string address, string jobname)
        {
            var result = "";
            if (address == null)
            {
                result = Sender("get", "api/companyManage/null/" + jobname, null);
            }
            else if (jobname == null)
            {
                result = Sender("get", "api/companyManage/" + address + "/null", null);
            }
            else
            {
                result = Sender("get", "api/companyManage/" + address + "/" + jobname, null);
            }
            List<CompanyManage> list = JsonConvert.DeserializeObject<List<CompanyManage>>(result);
            return View(list);
        }
    }
}