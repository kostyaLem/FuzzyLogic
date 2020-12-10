using System.Collections.Generic;

namespace FuzzyLogic.DAL.Models
{
    public sealed class MaterialColorDto : IdentityDto
    {
        public MaterialDto Material { get; set; }

        public List<ReportDto> Reports { get; set; }

        public string Name { get; set; }

        public string Recipe { get; set; }

        public byte[] Image { get; set; }

        public double B { get; set; }

        public double A { get; set; }

        public double L { get; set; }
    }
}
