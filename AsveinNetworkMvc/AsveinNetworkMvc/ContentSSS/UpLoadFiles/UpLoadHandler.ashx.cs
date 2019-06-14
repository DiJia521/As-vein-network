using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOT.Exam04Month04.UI.Handllers
{
    /// <summary>
    /// UpLoadHandler 的摘要说明
    /// </summary>
    public class UpLoadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;//获取上传文件的集合

            if (files.Count > 0)
            {
                HttpPostedFile file = files[0];//取得上传的文件
                file.SaveAs(context.Request.MapPath("/Images/") + file.FileName);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}