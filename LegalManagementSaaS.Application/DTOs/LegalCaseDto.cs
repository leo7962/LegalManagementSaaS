namespace LegalManagementSaaS.Application.DTOs
{
    public record LegalCaseDto(Guid Id, string Title, string Description, string ClientName, string Status);
}
