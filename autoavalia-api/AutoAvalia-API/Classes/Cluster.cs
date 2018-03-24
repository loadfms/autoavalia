using System.Collections.Generic;

namespace Webmotors.Api.Classes
{
	public class Cluster
	{
		public string Name { get; set; }
        public List<Question> questionList { get; set; }
        public List<Answer> answerList { get; set; }
    }
}