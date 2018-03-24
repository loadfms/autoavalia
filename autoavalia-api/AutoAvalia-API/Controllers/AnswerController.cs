using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Webmotors.Api.Classes;
using Webmotors.Shared.Database.NoSql;
using System.Linq;

namespace Webmotors.Api.Controllers
{
    public class AnswerController : CrudApi<Answer>
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [Route("api/answer/{questionnaireId}/{questionId}/{value}/{photo}")]
        public void Answer([FromBody] string questionnaireId, string questionId, bool value, string photo)
        {
            var answerRepo = new QuickRepository<Answer>();
            var questionRepo = new QuickRepository<Question>();
            answerRepo.Add(new Answer
            {
                QuestionId = questionId,
                QuestionnaireId = questionnaireId,
                Value = value,
                Photo = photo,
                AnsweredAt = DateTime.Now
            });

            //var question = questionRepo.Where(x => x.Id == questionId).FirstOrDefault();

            //question = questionRepo.Where(x => x.Order == question.Order + 1).FirstOrDefault();
        }

    }
}