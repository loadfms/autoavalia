using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Webmotors.Api.Classes;
using Webmotors.Shared.Database.NoSql;

namespace Webmotors.Api.Controllers
{
    public class AnswerController : CrudApi<Answer>
    {
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [Route("api/answer/{questionnaireId}/{questionId}/{value}")]
        public void Answer(string questionnaireId, string questionId, bool value, string photo)
        {
            var answerRepo = new QuickRepository<Answer>();
            answerRepo.Add(new Answer
            {
                QuestionId = questionId,
                QuestionnaireId = questionnaireId,
                Value = value,
                Photo = photo,
                AnsweredAt = DateTime.Now
            });
        }

    }
}