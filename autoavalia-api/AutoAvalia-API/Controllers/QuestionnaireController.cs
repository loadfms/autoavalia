using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Webmotors.Api.Classes;
using Webmotors.Shared.Database.NoSql;
using System.Web.Http.Cors;
using Webmotors.Shared.Caching;

namespace Webmotors.Api.Controllers
{
    public class QuestionnaireController : CrudApi<Questionnaire>
    {
        
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [Route("api/Questionnaire/{userId}/{advertiseId}")]
        public Questionnaire Questionnaire(int userId, int advertiseId)
        {
            var questionnaireRepo = new QuickRepository<Questionnaire>();
            var questionnaire = 
                questionnaireRepo.FirstOrDefault(x => x.UserId == userId && x.AdvertiseId == advertiseId) ?? 
                questionnaireRepo.Add(new Questionnaire
            {
                AdvertiseId = advertiseId,
                UserId = userId
            });

            List<Cluster> listCluster = Cached.Load("cached_listCluster",
                key => new QuickRepository<Cluster>().ToList());
            List<Question> listQuestion = Cached.Load("cached_listQuestion",
                key => new QuickRepository<Question>().ToList());
            List<Answer> listAnswer = new QuickRepository<Answer>()
                .Where(x => x.QuestionnaireId == questionnaire.Id)
                .ToList();
            List<Cluster> parsedClusters = listCluster.Select(x => {
                x.QuestionList = listQuestion.Where(
                    y => y.IdCluster == x.Id
                ).ToList();
                x.AnswerList = listAnswer.Where( y => 
                    x.QuestionList.Any(
                        z => z.Id == y.QuestionId
                    )
                ).ToList();
                return x;
            }).ToList();

            questionnaire.ClusterList = parsedClusters;

            return questionnaire;
        }
    }
}