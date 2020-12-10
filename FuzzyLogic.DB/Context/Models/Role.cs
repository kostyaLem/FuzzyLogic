using System;
using System.Collections.Generic;

#nullable disable

namespace FuzzyLogic.DB.Context.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Status { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
