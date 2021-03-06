﻿using System;
using System.Linq;
using Webmotors.Shared.Database.NoSql;
using Webmotors.Shared.Services;
using System.Web.Http;
using Webmotors.Api.Classes;

namespace Webmotors.Api.Controllers
{
    public class ReportController : CrudApi<Report>
    {
        [HttpGet]
        [Route("api/report/create/{questionnaireId}")]
        public Report CreateReport(string questionnaireId)
        {
            try
            {
                var service = new VehicleInformationService();
                var history = service.GetVehicleInformation("FFP6026");
                var reportRepository = new QuickRepository<Report>();
                var answerRepository = new QuickRepository<Answer>();
                var clusterRepository = new QuickRepository<Cluster>();
                var questionRepository = new QuickRepository<Question>();
                var questionnaireRepository = new QuickRepository<Questionnaire>();
                var questionnaire = questionnaireRepository.First(x => x.Id == questionnaireId);

                //if (questionnaire.Finished)
                //{
                //    return new Report {
                //        Error = true,
                //        Description = "Este questionário ja foi finalizado"
                //    };
                //}

                var clusters = clusterRepository.ToList();
                var questions = questionRepository.ToList();
                var answers = answerRepository.Where(x => x.QuestionnaireId == questionnaireId).ToList();
                var report = reportRepository.Add(new Report
                {
                    QuestionnaireId = questionnaire.Id,
                    State = new ReportState(),
                    History = new ReportHistory
                    {
                        OnwerQuantity = history.OnwerQuantity,
                        Recall = history.Recall,
                        Auction = history.Auction,
                        Accidents = history.Accidents,
                        Roberry = history.Roberry,
                    },
                    VehicleAdvert = new VehicleAdvert(),
                    Clusters = clusters.Select(x =>
                    {
                        var clusterQuestions = questions.Where(y => y.IdCluster == x.Id).ToList();
                        var clusterAnswers = answers.Where(y => y.Value && clusterQuestions.Any(z => z.Id == y.QuestionId));
                        return new ReportCluster
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Alias = x.Alias,
                            Answers = clusterAnswers.Select(y =>
                            {
                                var question = clusterQuestions.First(z => y.QuestionId == z.Id);
                                return new ReportAnswer {
                                    Name = question.Name,
                                    Price = question.Price,
                                    Photo = y.Photo
                                };
                            }).ToList()
                        };
                    }).ToList()
                });

                //questionnaire.Finished = true;
                //questionnaireRepository.Update(questionnaire);

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