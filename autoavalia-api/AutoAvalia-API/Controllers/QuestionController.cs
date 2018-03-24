using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Webmotors.Api.Classes;
using Webmotors.Shared.Database.NoSql;

namespace Webmotors.Api.Controllers
{
    public class QuestionController : CrudApi<Question>
    {

        [HttpGet]
        [Route("api/Question/{questionnaireId}/{clusterId}")]
        public Question ListQuestionByCluster(string questionnaireId, string clusterId)
        {


            return new Question();
        }
	}
}