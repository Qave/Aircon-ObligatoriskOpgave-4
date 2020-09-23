using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirconLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirConRestService.Controllers
{
    [Route("api/FanOutputs")]
    [ApiController]
    public class FanOutputController : ControllerBase
    {
        private static readonly List<FanOutput> Outputs = new List<FanOutput>()
         {
             new FanOutput(1,"First Output",17,40),
             new FanOutput(2,"Second Output", 20, 55),
             new FanOutput(3,"Third Output", 22, 43),
             new FanOutput(4,"Fourth Output", 24, 80),
             new FanOutput(5,"Fifth Output",16, 60)
         };
        // GET: api/<FanOutputController>
        [HttpGet]
        public IEnumerable<FanOutput> Get()
        {
            return Outputs;
        }

        // GET api/<FanOutputController>/5
        [HttpGet("{id}")]
        public FanOutput Get(int id)
        {
            return Outputs.Find(i => i.Id == id);
        }

        // POST api/<FanOutputController>
        [HttpPost]
        public void Post([FromBody] FanOutput value)
        {
            Outputs.Add(value);
        }

        // PUT api/<FanOutputController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutput value)
        {
            FanOutput output = Get(id);
            if (output != null)
            {
                output.Id = value.Id;
                output.Name = value.Name;
                output.Temp = value.Temp;
                output.Humidity = value.Humidity;
            }
        }

        // DELETE api/<FanOutputController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutput item = Get(id);
            Outputs.Remove(item);
        }
    }
}
