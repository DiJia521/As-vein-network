using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
using System.Net.Http;

namespace AsveinNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsveinNetworkController : ControllerBase
    {        
        AsvienNetworkBll bll = new AsvienNetworkBll();
        // GET: api/values
        [HttpGet]
        public IEnumerable<AsveinNetwork> Get()
        {
            return bll.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public AsveinNetwork Get(int id)
        {
            return bll.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]AsveinNetwork network)
        {
            if (ModelState.IsValid)
                bll.Add(network);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AsveinNetwork network)
        {
            network.Join_Id = id;
            if (ModelState.IsValid)
                bll.Update(network);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bll.Delete(id);
        }
    }
}