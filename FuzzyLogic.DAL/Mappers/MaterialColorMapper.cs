using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context.Models;
using System.Linq;

namespace FuzzyLogic.DAL.Mappers
{
    internal static class MaterialColorMapper
    {
        internal static MaterialColorDto MapToDto(this MaterialColor materialColor)
        {
            return new MaterialColorDto
            {
                Id = materialColor.Id,
                A = materialColor.A,
                B = materialColor.B,
                L = materialColor.L,
                Image = materialColor.Image,
                Name = materialColor.Name,
                Recipe = materialColor.Recipe,
                Material = materialColor.Material.MapToDto(),
                Reports = materialColor.Reports.Select(r => r.MapToDto()).ToList()
            };
        }

        internal static MaterialColor MapToEntity(this MaterialColorDto materialColorDto)
        {
            return new MaterialColor
            {
                Id = materialColorDto.Id,
                A = materialColorDto.A,
                B = materialColorDto.B,
                L = materialColorDto.L,
                Image = materialColorDto.Image,
                MaterialId = materialColorDto.Material.Id,
                Material = materialColorDto.Material.MapToEntity(),
                Name = materialColorDto.Name,
                Recipe = materialColorDto.Recipe,
                Reports = materialColorDto.Reports.Select(m => m.MapToEntity()).ToList()
            };
        }
    }
}
