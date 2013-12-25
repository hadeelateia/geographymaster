using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Models
{
    public class ScoreSession
    {
        public int TotalScore { get; set; }
        //category-score
        public Dictionary<long, int> ScoreByCategory { get; set; }
        public Dictionary<long, int> BadgeByCategory { get; set; }
    }
}