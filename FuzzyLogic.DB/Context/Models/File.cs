using System;
using System.Collections.Generic;

#nullable disable

namespace FuzzyLogic.DB.Context.Models
{
    public partial class File
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public byte[] Data { get; set; }
        public long Active { get; set; }
        public string Comment { get; set; }
    }
}
