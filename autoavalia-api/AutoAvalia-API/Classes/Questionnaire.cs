using System.Collections.Generic;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Questionnaire : IEntity<long>
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int AdvertiseId { get; set; }
        public List<Cluster> clusterList { get; set; }
        
    }
}