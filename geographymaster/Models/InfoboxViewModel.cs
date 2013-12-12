using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geographymaster.Models
{
    public class InfoboxViewModel
    {
        public long IdInfoBox { get; set; }
        public long IdCategory { get; set; }
        public string InfoBoxDescription { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public virtual Category Category { get; set; }
    }
}