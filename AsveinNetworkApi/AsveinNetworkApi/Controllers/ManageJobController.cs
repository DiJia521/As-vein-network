using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;

namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageJobController : ControllerBase
    {
        CompanyManageBll bll = new CompanyManageBll();
        /// <summary>
        /// 显示求职者
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ManageJob> GetManage(int selectId)
        {
            return bll.GetManege(selectId);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns></returns>
        [HttpPut]
        public int PutManege(ManageJob manageJob)
        {

            return bll.PutPass(manageJob);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="d_id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteMa(int d_id)
        {
            return bll.DeleteMa(d_id);
        }
    }
}