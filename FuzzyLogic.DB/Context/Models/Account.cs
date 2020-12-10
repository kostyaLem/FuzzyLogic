using System;
using System.Collections.Generic;

#nullable disable

namespace FuzzyLogic.DB.Context.Models
{
    public partial class Account
    {
        public Account()
        {
            Reports = new HashSet<Report>();
        }

        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
