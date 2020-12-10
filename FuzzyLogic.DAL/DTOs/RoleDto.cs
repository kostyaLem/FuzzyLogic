namespace FuzzyLogic.DAL.Models
{
    public sealed class RoleDto : IdentityDto
    {
        public string Name { get; set; }

        public AccountType AccountType { get; set; }
    }
}
