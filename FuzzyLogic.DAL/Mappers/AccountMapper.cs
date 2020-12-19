using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context.Models;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.DAL.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto MapToDto(this Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                Login = account.Login,
                Role = account.Role.MapToDto(),
                Reports = account.Reports?.Select(a => a.MapToDto()).ToList()
            };
        }

        internal static Account MapToEntity(this AccountDto accountDto)
        {
            return new Account
            {
                Id = accountDto.Id,
                Login = accountDto.Login,
                RoleId = accountDto.Role.Id,
                Password = accountDto.Password,
                Role = accountDto.Role.MapToEntity(),
                Reports = accountDto.Reports?.Select(m => m.MapToEntity()).ToList() ?? new List<Report>()
            };
        }
    }
}
