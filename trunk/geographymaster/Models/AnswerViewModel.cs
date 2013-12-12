using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Models
{
    public class AnswerViewModel
    {
        public string AnswerDescription { get; set; }
        public string QuestionDescription { get; set; }
        public long IdQuestion { get; set; }
        public long IdAnswer { get; set; }
        public bool IsTrue { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}