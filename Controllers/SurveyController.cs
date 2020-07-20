using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Connector;
using Survey.Models;
using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
    
        // GET api/values
        [HttpGet]
        public IEnumerable<SurveyClass> Get()
        {
            Connect mysqlGet = new Connect();
            return mysqlGet.SurveyList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SurveyClass Get(int id)
        {
            Connect mysqlGet = new Connect();
            return mysqlGet.SurveyById(id);

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SurveyClass newSurvey)
        {
            Connect mysqlGet = new Connect();
            mysqlGet.AddSurvey(newSurvey);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SurveyClass survey)
        {
            Connect mysqlGet = new Connect();
            mysqlGet.UpdateSurvey(id,survey);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            Connect mysqlGet = new Connect();
            mysqlGet.DeleteSurvey(id);
        }
    }
}