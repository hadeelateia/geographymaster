//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace geographymaster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public long IdScore { get; set; }
        public string PlayerName { get; set; }
        public int Score1 { get; set; }
        public long IdBadge { get; set; }
    
        public virtual Badge Badge { get; set; }
    }
}
