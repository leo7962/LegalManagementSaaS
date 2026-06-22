using LegalManagementSaaS.Application.DTOs;
using LegalManagementSaaS.Application.Interfaces;
using MediatR;

namespace LegalManagementSaaS.Application.Cases.Queries.GetLegalCases
{
    public record GetLegalCasesQuery(PaginationRequest Pagination) : IRequest<IEnumerable<LegalCaseDto>>;
}
