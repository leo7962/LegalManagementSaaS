using LegalManagementSaaS.Application.Interfaces;
using LegalManagementSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegalManagementSaaS.Infrastructure.Persistence.Repositories
{
    public class LegalCaseRepository : ILegalCaseRepository
    {
        private readonly ApplicationDbContext _context;
        public LegalCaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LegalCase>> GetAllAsync(PaginationRequest request, CancellationToken cancellationToken = default)
        {
            return await _context.LegalCases
                .AsNoTracking()
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(LegalCase legalCase, CancellationToken cancellationToken = default)
        {
            await _context.LegalCases.AddAsync(legalCase, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
