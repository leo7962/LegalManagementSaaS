namespace LegalManagementSaaS.Domain.Entities
{
    public class LegalNotification
    {
        public Guid Id { get; private set; }
        public Guid LegalCaseId { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        private LegalNotification() { }

        public LegalNotification(Guid id, Guid legalCaseId, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Notification message cannot be empty.", nameof(message));

            Id = id;
            LegalCaseId = legalCaseId;
            Message = message;
            CreatedAt = DateTime.Now;
        }
    }
}
