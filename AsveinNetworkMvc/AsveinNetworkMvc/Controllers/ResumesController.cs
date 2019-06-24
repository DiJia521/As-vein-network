using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AsveinNetworkMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace AsveinNetworkMvc.Controllers
{
    public class ResumesController : Controller
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
                case "delete": //删除
                    responseMessage = client.DeleteAsync(path).Result;
                    break;
                case "put": //修改
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

        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 显示简历
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ShowResumes(string name)
        {
            string str = Sender("get", "api/Resumes/GetResumes/" + name, null);
            List<Resumes> list = JsonConvert.DeserializeObject<List<Resumes>>(str);
            return View(list);
        }


        private IHostingEnvironment hostingEnv;
        public ResumesController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        /// <summary>
        /// 添加简历
        /// </summary>
        /// <param name="resumes"></param>
        public IActionResult AddResumes()
        {

            return View();
        }


        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="R_Picture"></param>
        /// <param name="resum"></param>
        [HttpPost]
        public void AddResumes(IList<IFormFile> R_Picture, Resumes resum)
        {
            long size = 0;
            var filename = "";
            foreach (var file in R_Picture)
            {
                filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                //这个hostingEnv.WebRootPath就是要存的地址可以改下
                filename = hostingEnv.WebRootPath + $@"\images\{filename}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            //添加信息
            if (resum != null)
            {
                resum.R_Picture = R_Picture[0].FileName;
                string json = JsonConvert.SerializeObject(resum);
                string ss = Sender("post", "/api/Resumes", json);
                if (int.Parse(ss) > 0)
                {
                    Response.Redirect("/Resumes/ShowResumes?name=" + resum.R_Name);
                }
                else
                {
                    Response.WriteAsync("<script>alert('添加失败')</script>");
                }
            }

        }


        /// <summary>
        /// 反添简历信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateResumes(int id)
        {
            var up = Sender("get", "/api/Resumes/" + id, null);
            var zhuan = JsonConvert.DeserializeObject<Resumes>(up);
            return View(zhuan);
        }


        /// <summary>
        /// 修改简历信息
        /// </summary>
        /// <param name="resutt"></param>
        /// <param name="R_Picture"></param>
        ///// <param name="imgrl"></param>
        [HttpPost]
        public void UpdateResumes(IList<IFormFile> R_Picture, Resumes resutt)
        {
            long size = 0;
            var filename = "";
            foreach (var file in R_Picture)
            {
                filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                //这个hostingEnv.WebRootPath就是要存的地址可以改下
                filename = hostingEnv.WebRootPath + $@"\images\{filename}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }


            //修改信息
            resutt.R_Picture = R_Picture[0].FileName;
            string json = JsonConvert.SerializeObject(resutt);
            var rest = Sender("put", "/api/Resumes/UpdateResumes", json);
            if (Convert.ToInt32(rest) > 0)
            {
                Response.Redirect("/Resumes/ShowResumes?name=" + resutt.R_Name);

            }
            else
            {
                Content("<script>alert('修改失败')</script>", "text/html");
            }
        }


    }
}