using System;

namespace FuzzyLogic.DAL.Models
{
    public sealed class ReportDto : IdentityDto
    {
        public AccountDto Account { get; set; }

        public MaterialDto Material { get; set; }

        public MaterialColorDto Color { get; set; }

        public byte[] Image { get; set; }

        public DateTime Date { get; set; }

        public double B { get; set; }

        public double A { get; set; }

        public double L { get; set; }
    }
}
