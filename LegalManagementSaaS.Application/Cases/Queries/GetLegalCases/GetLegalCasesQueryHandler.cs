using AutoMapper;
using LegalManagementSaaS.Application.DTOs;
using LegalManagementSaaS.Application.Interfaces;
using MediatR;

namespace LegalManagementSaaS.Application.Cases.Queries.GetLegalCases
{
    public class GetLegalCasesQueryHandler : IRequestHandler<GetLegalCasesQuery, IEnumerable<LegalCaseDto>>
    {
        private readonly ILegalCaseRepository _repository;
        private readonly IMapper _mapper;

        public GetLegalCasesQueryHandler(ILegalCaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LegalCaseDto>> Handle(GetLegalCasesQuery request, CancellationToken cancellationToken)
        {
            var cases = await _repository.GetAllAsync(request.Pagination, cancellationToken);
            return _mapper.Map<IEnumerable<LegalCaseDto>>(cases);
        }
    }
}
