using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Webmotors.Api.Classes;
using Webmotors.Api.Controllers;
using Webmotors.Shared.Database.NoSql;

namespace AutoAvalia_API.Controllers
{
    public class QuestionController : CrudApi<Question, long>
    {

        [HttpGet]
        [Route("api/Question/{userId}/{advertiseId}/{cluster}")]
        public List<Question> ListQuestionByCluster(int userId, int advertiseId, string cluster)
        {
            return new List<Question>();
        }
	}
}