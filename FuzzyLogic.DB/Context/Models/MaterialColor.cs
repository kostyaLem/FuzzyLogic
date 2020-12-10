using System;
using System.Collections.Generic;

#nullable disable

namespace FuzzyLogic.DB.Context.Models
{
    public partial class MaterialColor
    {
        public MaterialColor()
        {
            Reports = new HashSet<Report>();
        }

        public long Id { get; set; }
        public long MaterialId { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public byte[] Image { get; set; }
        public double B { get; set; }
        public double A { get; set; }
        public double L { get; set; }

        public virtual Material Material { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
