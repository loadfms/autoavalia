using System;
using System.Linq;
using System.Web.Mvc;
using Webmotors.Api.Classes;
using Webmotors.Shared.Database.NoSql;

namespace Webmotors.Api.Controllers
{
    public class ReportController : CrudApi<Report>
    {
        [HttpPost]
        [Route("api/report/create/{questionnaireId}")]
        public Report CreateReport(string questionnaireId)
        {
            try
            {
                var reportRepository = new QuickRepository<Report>();
                var questionnaireRepository = new QuickRepository<Questionnaire>();
                var questionnaire = questionnaireRepository.First(x => x.Id == questionnaireId);
                var report = reportRepository.Add(new Report
                {
                    QuestionnaireId = questionnaire.Id,
                    State = new ReportState(),
                    History = new ReportHistory(),
                    VehicleAdvert = new VehicleAdvert()
                });

                questionnaire.Finished = true;
                questionnaireRepository.Update(questionnaire);

                return report;
            }
            catch (Exception)
            {
                return new Report {
                    Error = true,
                    Description = "Não foi possível consolidar as informações do formulário"
                };
            }
        }
    }
}