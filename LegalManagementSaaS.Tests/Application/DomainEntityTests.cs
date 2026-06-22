using FluentAssertions;
using LegalManagementSaaS.Domain.Entities;

namespace LegalManagementSaaS.Tests.Application
{
    public class DomainEntityTests
    {
        [Fact]
        public void LegalCase_ShouldThrowArgumentException_WhenTitleIsEmpty()
        {
            // Arrange
            Action action = () => new LegalCase(Guid.NewGuid(), "", "Some description", "John Doe");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithParameterName("title");
        }

        [Fact]
        public void AddNotification_ShouldIncreaseNotificationCount()
        {
            // Arrange
            var legalCase = new LegalCase(Guid.NewGuid(), "Valid Title", "Description", "Client X");

            // Act
            legalCase.AddNotification("First hearing scheduled.");

            // Assert
            legalCase.Notifications.Should().HaveCount(1);
            legalCase.Notifications.First().Message.Should().Be("First hearing scheduled.");
        }
    }
}
