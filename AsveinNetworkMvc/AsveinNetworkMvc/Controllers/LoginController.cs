using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsveinNetworkMvc.Controllers
{
    public class LoginController : Controller
    {

        public string GetApiResult(string request, string actionName, object obj = null)
        {
            //创建返回字符串
            string json = "";
            //实例化HTTP客户端
            HttpClient hc = new HttpClient();
            //配置HTTP客户端要访问的服务器地址  主机名+端口+API+控制器+/
            hc.BaseAddress = new Uri("https://localhost:44370/api/login/");
            //创建取服务器端回包的任务
            Task<HttpResponseMessage> task = null;
            //根据不同的请求方式,发送不同的请求包
            switch (request)
            {
                case "get":
                    task = hc.GetAsync(actionName);
                    break;
                case "post":
                    task = hc.PostAsJsonAsync(actionName, obj);
                    break;
                case "put":
                    task = hc.PutAsJsonAsync(actionName, obj);
                    break;
                case "delete":
                    task = hc.DeleteAsync(actionName);
                    break;
            }
            task.Wait();
            // tcp / ip 第二次握手 客户端hc确认接受回包
            var result = task.Result;
            //tcp/ip 第三次握手 客户端hc确认回包完整性
            if (result.IsSuccessStatusCode)
            {
                //获取回包里面我们所需要的数据转化为字符串
                var getresultTask = result.Content.ReadAsStringAsync();

                getresultTask.Wait();

                //获取转换为字符串的最终结果
                json = getresultTask.Result;
            }

            return json;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public void Login(string Name,string Pwd)
        {
            string result = GetApiResult("get", "GetLogin?UserName=" + Name + "&pwd=" + Pwd);
        }
    }
}