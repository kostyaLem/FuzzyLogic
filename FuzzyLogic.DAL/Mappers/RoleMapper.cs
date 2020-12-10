using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context.Models;

namespace FuzzyLogic.DAL.Mappers
{
    public static class RoleMapper
    {
        public static RoleDto MapToDto(this Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                AccountType = (AccountType)role.Status
            };
        }

        internal static Role MapToEntity(this RoleDto roleDto)
        {
            return new Role
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
                Status = (int)roleDto.AccountType
            };
        }
    }
}
