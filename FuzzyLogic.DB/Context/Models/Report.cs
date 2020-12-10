using System;
using System.Collections.Generic;

#nullable disable

namespace FuzzyLogic.DB.Context.Models
{
    public partial class Report
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public double B { get; set; }
        public double A { get; set; }
        public double L { get; set; }
        public byte[] Image { get; set; }
        public long? MaterialColorId { get; set; }
        public long? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual MaterialColor MaterialColor { get; set; }
    }
}
