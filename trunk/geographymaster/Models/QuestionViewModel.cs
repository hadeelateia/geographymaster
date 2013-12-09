using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace geographymaster.Models
{
    public class QuestionViewModel
    {
        public Question QuestionDetails { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        
        public long CategoryId { get; set; }
        public long QuestionId { get; set; }
    }
}