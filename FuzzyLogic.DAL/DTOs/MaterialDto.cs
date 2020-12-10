using System.Collections.Generic;

namespace FuzzyLogic.DAL.Models
{
    public sealed class MaterialDto : IdentityDto
    {
        public string Name { get; set; }

        public List<MaterialColorDto> Colors { get; set; }
    }
}
