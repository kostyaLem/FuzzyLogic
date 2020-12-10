using System;
using System.Collections.Generic;

#nullable disable

namespace FuzzyLogic.DB.Context.Models
{
    public partial class Material
    {
        public Material()
        {
            MaterialColors = new HashSet<MaterialColor>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MaterialColor> MaterialColors { get; set; }
    }
}
