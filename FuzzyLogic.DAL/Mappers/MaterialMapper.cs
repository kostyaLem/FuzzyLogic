using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context.Models;
using System.Linq;

namespace FuzzyLogic.DAL.Mappers
{
    internal static class MaterialMapper
    {
        internal static MaterialDto MapToDto(this Material material)
        {
            return new MaterialDto
            {
                Id = material.Id,
                Name = material.Name,                
                Colors = material.MaterialColors.Select(m => m.MapToDto()).ToList()
            };
        }

        internal static Material MapToEntity(this MaterialDto materialDto)
        {
            return new Material
            {
                Id = materialDto.Id,
                Name = materialDto.Name,
                MaterialColors = materialDto.Colors.Select(m => m.MapToEntity()).ToList()
            };
        }
    }
}
