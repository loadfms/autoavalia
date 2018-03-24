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
        [Route("api/answer")]
        public void Answer([FromBody] answerPost _answer)
        {
            var answerRepo = new QuickRepository<Answer>();
            var questionRepo = new QuickRepository<Question>();
            answerRepo.Add(new Answer
            {
                QuestionId = _answer.QuestionId,
                QuestionnaireId = _answer.QuestionnaireId,
                Value = _answer.Value,
                Photo = _answer.Photo
            });

            //var question = questionRepo.Where(x => x.Id == questionId).FirstOrDefault();

            //question = questionRepo.Where(x => x.Order == question.Order + 1).FirstOrDefault();
        }

        public class answerPost
        {
            public string QuestionId;
            public string QuestionnaireId;
            public bool Value;
            public string Photo;
        }

    }
}