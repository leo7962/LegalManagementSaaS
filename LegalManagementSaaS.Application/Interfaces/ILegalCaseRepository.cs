using LegalManagementSaaS.Domain.Entities;

namespace LegalManagementSaaS.Application.Interfaces
{
    public record PaginationRequest(int PageNumber = 1, int PageSize = 10);

    public interface ILegalCaseRepository
    {
        Task<IEnumerable<LegalCase>> GetAllAsync(PaginationRequest request, CancellationToken cancellationToken = default);
        Task AddAsync(LegalCase legalCase, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
