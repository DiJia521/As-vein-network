﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace AsveinNetworkMvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录+注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public IActionResult Czmm1()
        {
            return View();
        }

        public IActionResult Czmm2()
        {
            return View();
        }

        public IActionResult Czmm3()
        {
            return View();
        }

        public ActionResult SendNET(string PhoneNumber)
        {
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = "LTAIcLO59PW1JYVJ";//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = "N0QsKnIhcbrSiXrWS7eaqWrvGXEaGB";//你的accessKeySecret，参考本文档步骤2

            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            string intString = "";
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”
                request.PhoneNumbers = PhoneNumber;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "职脉网";
                //必填:短信模板-可在短信控制台中找到，发送国际/港澳台消息时，请使用国际/港澳台短信模版
                request.TemplateCode = "SMS_167396911";
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                Random random = new Random(Guid.NewGuid().GetHashCode());
                intString = random.Next(1000, 9999).ToString();
                request.TemplateParam = "{\"code\":" + intString + "}";

                
               
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                //request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);

                System.Console.WriteLine(sendSmsResponse.Message);
            }
            catch (ServerException e)
            {
                System.Console.WriteLine("Hello World！");
            }
            catch (ClientException e)
            {
                System.Console.WriteLine("Hello World！");
            }
            

            return Json(intString);
        }
    }
}