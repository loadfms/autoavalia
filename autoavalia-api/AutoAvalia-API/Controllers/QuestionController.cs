using System.Collections.Generic;
using System.Web.Http;
using Webmotors.Api.Classes;

namespace Webmotors.Api.Controllers
{
    public class QuestionController : CrudApi<Question>
    {

        [HttpGet]
        [Route("api/Question/{userId}/{advertiseId}/{cluster}")]
        public List<Question> ListQuestionByCluster(int userId, int advertiseId, string cluster)
        {
            return new List<Question>();
        }
	}
}