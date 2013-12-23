using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Models
{
    public class ScoreSession
    {
        public int TotalScore { get; set; }
        public Dictionary<int, int> ScoreByCategory { get; set; }
    }
}