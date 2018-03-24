using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Webmotors.Api.Classes;
using Webmotors.Api.Controllers;
using Webmotors.Shared.Database.NoSql;

namespace AutoAvalia_API.Controllers
{
    public class QuestionController : CrudApi<Question, long>
    {
		[HttpGet]
		[Route("api/Clusters/{userId}/{advertiseId}")]
		public List<Cluster> ListCluster(int userId, int advertiseId)
		{
            //List<Cluster> listCluster = new QuickRepository<Question, long>().GroupBy(x => x.Cluster)
            //    .Select(group => new Cluster
            //    {
            //        Name = group.Key
            //    }).ToList();

            List<Question> listQuestion = new QuickRepository<Question, long>().ToList();

            List<Cluster> listCluster = listQuestion.GroupBy(x => x.Cluster)
                .Select(group => new Cluster
                {
                    Name = group.Key
                }).ToList();

            return listCluster;
		}

        [HttpGet]
        [Route("api/Question/{userId}/{advertiseId}/{cluster}")]
        public List<Question> ListQuestionByCluster(int userId, int advertiseId, string cluster)
        {
            return new List<Question>();
        }
	}
}