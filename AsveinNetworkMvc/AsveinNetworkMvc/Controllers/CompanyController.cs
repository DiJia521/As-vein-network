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
    public class CompanyController : Controller
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

        /// <summary>
        /// 公司显示
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult CompanyIndex(string phone)
        {
            string str = Sender("get", "api/Company/GetCompany/" + phone, null);
            var model = JsonConvert.DeserializeObject<List<Company>>(str);
            return View(model);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public IActionResult Xgmm()
        {
            return View();
        }

        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertAddCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertAddCompany(Company com)
        {
            string json = JsonConvert.SerializeObject(com);
            string ss = Sender("post", "/api/Company/", json);
            if (Convert.ToInt32(ss) > 0)
            {
                Response.Redirect("/Company/CompanyIndex?phone=" + com.CompanyPhone);
            }
            return View();
        }
    }
}