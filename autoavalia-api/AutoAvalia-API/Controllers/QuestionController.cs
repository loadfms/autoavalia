using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Webmotors.Api.Classes;
using System.Web.Http.Cors;
using Webmotors.Shared.Database.NoSql;

namespace Webmotors.Api.Controllers
{
    public class QuestionController : CrudApi<Question>
    {

        [HttpGet]
        [Route("api/Question/{questionnaireId}/{clusterId}")]
        public Question ListQuestionByCluster(string questionnaireId, string clusterId)
        {
            var questionRepo = new QuickRepository<Question>();
            var clusterRepo = new QuickRepository<Cluster>();
            var answerRepo = new QuickRepository<Answer>();

            var answer = answerRepo.Where(x => x.QuestionnaireId == questionnaireId).ToList();
            var question = questionRepo.Where(x => x.IdCluster == clusterId).ToList();


             var filterAdd = question.FirstOrDefault(x => !answer.Any (y => y.QuestionId == x.Id));


            return filterAdd;
        }
	}
}