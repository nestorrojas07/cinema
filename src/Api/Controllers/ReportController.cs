using Api.Mappers;
using Api.Requests.Movie;
using Api.Requests.ShowSchedules;
using Application.Services;
using ClosedXML.Excel;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ShowScheduleService _showScheduleService;

    public ReportController(ShowScheduleService showScheduleService)
    {
        _showScheduleService = showScheduleService;
    }


    [HttpGet("show-schedule")]
    public async Task<ActionResult> ShowScheduleReportXlsx([FromQuery] ShowScheduleSearchRequest request)
    {
        var shows = await _showScheduleService.GetAllAsync(request.ToShowScheduleSearch());

        System.IO.Stream spreadsheetStream = new System.IO.MemoryStream();
        XLWorkbook workbook = new XLWorkbook();
        IXLWorksheet worksheet = workbook.Worksheets.Add("example");
        int row = 1;
        worksheet.Cell(row, 1).SetValue("Movie");
        worksheet.Cell(row, 2).SetValue("Duration");
        worksheet.Cell(row, 3).SetValue("Start at");
        worksheet.Cell(row, 4).SetValue("End at");
        worksheet.Cell(row, 5).SetValue("Seats sold");
        foreach (var show in shows)
        {
            row++;
            worksheet.Cell(row, 1).SetValue(show.Movie?.Title);
            worksheet.Cell(row, 2).SetValue(show.Movie?.DurationMinutes);
            worksheet.Cell(row, 3).SetValue(show.From.ToString("O"));
            worksheet.Cell(row, 4).SetValue(show.From.ToString("O"));
            worksheet.Cell(row, 5).SetValue(show.SeatsSold);
        }

        workbook.SaveAs(spreadsheetStream);
        spreadsheetStream.Position = 0;

        return new FileStreamResult(spreadsheetStream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") 
            { FileDownloadName = $"shows-staticstics.xlsx" };
    }
}