﻿using System.Collections.Generic;

namespace Webmotors.Api.Classes
{
    public class Cluster
    {
        public string Name { get; set; }
        public List<Question> QuestionList { get; set; }
        public List<Answer> AnswerList { get; set; }


        // Calculated Properties
        public int QuestionsAnswered => AnswerList?.Count ?? 0;
        public int Questions => QuestionList?.Count ?? 0;
        public int Completeness =>
            QuestionsAnswered > 0 ? Questions / QuestionsAnswered : 0;
    }
}