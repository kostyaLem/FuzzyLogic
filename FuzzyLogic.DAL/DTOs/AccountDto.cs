using System.Collections.Generic;

namespace FuzzyLogic.DAL.Models
{
    public sealed class AccountDto : IdentityDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public RoleDto Role { get; set; }

        public List<ReportDto> Reports { get; set; }
    }
}
