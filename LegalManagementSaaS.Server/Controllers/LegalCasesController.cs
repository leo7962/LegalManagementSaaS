using LegalManagementSaaS.Application.Cases.Commands.CreateLegalCase;
using LegalManagementSaaS.Application.Cases.Queries.GetLegalCases;
using LegalManagementSaaS.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LegalManagementSaaS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalCasesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LegalCasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase([FromBody] CreateLegalCaseCommand command)
        {
            var caseId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCases), new { id = caseId }, new { Id = caseId });
        }

        [HttpGet]
        public async Task<IActionResult> GetCases([FromQuery] PaginationRequest pagination)
        {
            // Using an object as input parameter ensures clean and extensible method signatures
            var cases = await _mediator.Send(new GetLegalCasesQuery(pagination));
            return Ok(cases);
        }

        // Explicit manual endpoints for report generation preserved for the UI
        [HttpGet("reports/excel")]
        public IActionResult GenerateExcelReport()
        {
            // TODO: Implement actual Excel generation logic
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("Dummy Excel Content");
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LegalCasesReport.xlsx");
        }

        [HttpGet("reports/pdf")]
        public IActionResult GeneratePdfReport()
        {
            // TODO: Implement actual PDF generation logic
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("Dummy PDF Content");
            return File(fileBytes, "application/pdf", "LegalCasesReport.pdf");
        }
    }
}
