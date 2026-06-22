using MediatR;

namespace LegalManagementSaaS.Application.Cases.Commands.CreateLegalCase
{
    public record CreateLegalCaseCommand(string Title, string Description, string ClientName) : IRequest<Guid>;
}
