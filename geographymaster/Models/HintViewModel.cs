using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Models
{
    public class HintViewModel
    {
        public long IdHint { get; set; }
        public long IdQuestion { get; set; }
        public string QuestionDescription { get; set; }
        public string HintDescription { get; set; }

        public virtual Question Question { get; set; }

        public IEnumerable<Hint> Hints { get; set; }
    }
}