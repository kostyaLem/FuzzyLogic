using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DB.Context.Models;
using System.Collections.Generic;

namespace FuzzyLogic.DAL.Models
{
    public sealed class AccountDto : IdentityDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public RoleDto Role { get; set; }

        public List<ReportDto> Reports { get; set; }

        #region Base

        //protected override IdentityDto MapToDto(object entity)
        //{
        //    return AccountMapper.MapToDto(entity as Account);
        //}

        //protected override object MapToEntity(IdentityDto entityDto)
        //{
        //    return AccountMapper.MapToEntity(entityDto as AccountDto);
        //}

        //internal override void Validate()
        //{
        //    throw new System.NotImplementedException();
        //}

        #endregion
    }
}
