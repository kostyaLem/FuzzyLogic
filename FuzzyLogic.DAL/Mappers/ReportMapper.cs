using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context.Models;
using System;

namespace FuzzyLogic.DAL.Mappers
{
    internal static class ReportMapper
    {
        internal static ReportDto MapToDto(this Report report)
        {
            return new ReportDto
            {
                Id = report.Id,
                A = report.A,
                B = report.B,
                L = report.L,
                Color = report.MaterialColor.MapToDto(),
                Account = report.Account.MapToDto(),
                Image = report.Image,
                Date = DateTime.Parse(report.Date),
                Material = report.MaterialColor.Material.MapToDto()
            };
        }

        internal static Report MapToEntity(this ReportDto reportDto)
        {
            return new Report
            {
                Id = reportDto.Id,
                A = reportDto.A,
                B = reportDto.B,
                L = reportDto.L,
                MaterialColor = reportDto.Color.MapToEntity(),
                AccountId = reportDto.Account.Id,
                Account = reportDto.Account.MapToEntity(),
                Date = reportDto.Date.ToString(),
                Image = reportDto.Image,
                MaterialColorId = reportDto.Material.Id
            };
        }
    }
}
