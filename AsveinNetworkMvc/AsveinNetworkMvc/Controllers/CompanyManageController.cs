using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsveinNetworkMvc.Models;
using Newtonsoft.Json;

namespace AsveinNetworkMvc.Controllers
{
    public class CompanyManageController : Controller
    {
        public  string  Sender(string method,string path,string content)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage responseMessage = null;
            switch(method)
            {
                case "get": //查询
                    responseMessage = client.GetAsync(path).Result;
                    break;
                case "post": //添加
                    HttpContent httpContent = new StringContent(content);
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    responseMessage = client.PostAsync(path,httpContent).Result;
                    break;
                case "delete": //查询
                    responseMessage = client.DeleteAsync(path).Result;
                    break;
                case "put": //查询
                    HttpContent httpContent1 = new StringContent(content);
                    httpContent1.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    responseMessage = client.PutAsync(path,httpContent1).Result;

                    break;
                default:break;

            }
            if(responseMessage.IsSuccessStatusCode==true)
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
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyManage company)
        {
            if(company!=null)
            {
                string json = JsonConvert.SerializeObject(company);
               string result=  Sender("post", "/api/CompanyManage",json);
                if(result!="失败")
                {

                    Response.Redirect("/CompanyManage/SeadEmail");
                }
            }
            return View();
        }
        public IActionResult SeadEmail()
        {
            return View();
        }
    }
}