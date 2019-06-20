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
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyManage company)
        {
            if (company != null)
            {
                string json = JsonConvert.SerializeObject(company);
                string result = Sender("post", "/api/CompanyManage", json);
                if (result != "失败")
                {

                    Response.Redirect("/CompanyManage/SeadEmail?email=" + company.C_EmailAddress + "&name=" + company.C_Name + "&jobr=" + company.C_JobRequirements);
                }
            }
            return View();
        }
        public IActionResult SeadEmail(string email, string name, string jobr)
        {
            ViewBag.email = email;
            ViewBag.job = jobr;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.163.com";//使用163的SMTP服务器发送邮件
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("W_xy9992@163.com", "XY9992");//163的SMTP服务器需要用163邮箱的用户名和smtp授权码作认证，如果没有需要去163申请个,
            //这里假定你已经拥有了一个163邮箱的账户，用户名为abc，密码为*******
            System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            Message.From = new System.Net.Mail.MailAddress("W_xy9992@163.com");//这里需要注意，163似乎有规定发信人的邮箱地址必须是163的，而且发信人的邮箱用户名必须和上面SMTP服务器认证时的用户名相同
                                                                               //因为上面用的用户名abc作SMTP服务器认证，所以这里发信人的邮箱地址也应该写为abc@163.com

            Message.To.Add(email);//将邮件发送给Gmail

            //Message.To.Add("123456@gmail.com");//将邮件发送给Gmail
            //Message.To.Add("123456@qq.com");//将邮件发送给QQ邮箱
            Message.Subject = "职脉网通知";
            string name1 = name.Substring(0, 1);
            Message.Body = "恭喜" + name1 + "先生，您在职脉网发布成功，<br/> 祝您找到优秀的员工";
            Message.SubjectEncoding = System.Text.Encoding.UTF8;
            Message.BodyEncoding = System.Text.Encoding.UTF8;
            Message.Priority = System.Net.Mail.MailPriority.High;
            Message.IsBodyHtml = true;　　//可以为html
            try
            {
                client.Send(Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }


            return View();
        }

        /// <summary>
        /// 职位详情
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult jobMessages(string name)
        {
            string str = Sender("get", "api/CompanyManage/GetJobMessage/" + name, null);
            var model = JsonConvert.DeserializeObject<List<CompanyManage>>(str);
            return View(model);
        }

        //提交简历
        public ActionResult PostResumes(string cname,string position,string address,string rName,string rPhone,string rAge,string rAddress,string rSalary)
        {
            ManageJob job = new ManageJob();
            job.C_CompanyName = cname;
            job.C_AvailablePositions = position;
            job.C_CompanyAddress = address;
            job.R_Name = rName;
            job.R_Phone = rPhone;
            job.R_Age = Convert.ToInt32(rAge);
            job.R_EmailAddress = rAddress;
            job.M_Pass = 0;
            job.C_TypeLabor = rSalary;

            string json = JsonConvert.SerializeObject(job);
            var result = Sender("post", "api/Resumes/AddManageJob", json);

            return Json(result);
        }
    }
}