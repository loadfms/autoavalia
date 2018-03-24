using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmotors.Api.Classes;
using Webmotors.Shared.Database.NoSql;

namespace Webmotors.Api.Controllers
{
    public class QuestionnaireController : CrudApi<Questionnaire, long>
    {
        public void Start(int userId, int advertiseId)
        {

        }

        [HttpGet]
        [Route("api/Questionnaire/{userId}/{advertiseId}")]
        public Questionnaire questionnaire(int userId, int advertiseId)
        {
            var questionnaireRepo = new QuickRepository<Questionnaire, long>();
            var questionnaire = questionnaireRepo.FirstOrDefault();

            if (questionnaire == null)
            {
                questionnaire = questionnaireRepo.Add(new Questionnaire()
                {
                    AdvertiseId = advertiseId,
                    UserId = userId
                });
            }


            List<Question> listQuestion = new QuickRepository<Question, long>().ToList();
            List<Answer> listAnswer = new QuickRepository<Answer, string>().Where(x => x.QuestionnaireId == questionnaire.Id).ToList();


            List<Cluster> listCluster = listQuestion.GroupBy(x => x.Cluster, y => y)
                .Select(group => new Cluster
                {
                    Name = group.Key,
                    questionList = group.ToList(),
                    answerList = listAnswer.Where(x => group.Any (y => y.Id.Equals (x.QuestionId))).ToList()

                }).ToList();
            questionnaire.clusterList = listCluster;

            //Questionnaire questionnaire = new Questionnaire()
            //{
            //    clusterList = listCluster,
            //    AdvertiseId = advertiseId,
            //    UserId = userId
            //};

            return questionnaire;
        }
    }
}