using LegalManagementSaaS.Domain.Enums;

namespace LegalManagementSaaS.Domain.Entities
{
    public class LegalCase
    {
        private readonly List<LegalNotification> _notifications = new();

        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string ClientName { get; private set; } = string.Empty;
        public CaseStatus Status { get; private set; }

        public IReadOnlyCollection<LegalNotification> Notifications => _notifications.AsReadOnly();

        private LegalCase() { }

        public LegalCase(Guid id, string title, string description, string clientName)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(clientName))
                throw new ArgumentException("Client name cannot be empty.", nameof(clientName));

            Id = id;
            Title = title;
            Description = description;
            ClientName = clientName;
            Status = CaseStatus.open; //Default status when a case is created
        }

        // Business Behavior: Updating the status explicitly
        public void UpdateStatus(CaseStatus newStatus)
        {
            if (Status == newStatus)
                throw new InvalidOperationException("The case is already in the specified status.");
            Status = newStatus;
        }

        // Business Behavior: Adding a notification through the Aggregate Root
        public void AddNotification(string message)
        {
            var notification = new LegalNotification(Guid.NewGuid(), Id, message);
            _notifications.Add(notification);
        }
    }
}
