using LegalManagementSaaS.Application.Interfaces;
using LegalManagementSaaS.Domain.Entities;
using MediatR;

namespace LegalManagementSaaS.Application.Cases.Commands.CreateLegalCase
{
    public class CreateLegalCaseCommandHandler : IRequestHandler<CreateLegalCaseCommand, Guid>
    {
        private readonly ILegalCaseRepository _repository;

        public CreateLegalCaseCommandHandler(ILegalCaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateLegalCaseCommand request, CancellationToken cancellationToken)
        {
            var newCase = new LegalCase(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.ClientName
                );

            await _repository.AddAsync(newCase, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return newCase.Id;
        }
    }
}
