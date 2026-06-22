using FluentAssertions;
using LegalManagementSaaS.Application.Cases.Commands.CreateLegalCase;
using LegalManagementSaaS.Application.Interfaces;
using LegalManagementSaaS.Domain.Entities;
using Moq;

namespace LegalManagementSaaS.Tests.Application
{
    public class CreateLegalCaseCommandHandlerTests
    {
        private readonly Mock<ILegalCaseRepository> _repositoryMock;
        private readonly CreateLegalCaseCommandHandler _handler;

        public CreateLegalCaseCommandHandlerTests()
        {
            _repositoryMock = new Mock<ILegalCaseRepository>();
            _handler = new CreateLegalCaseCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateCaseAndReturnGuid_WhenValidCommandIsProvided()
        {
            // Arrange
            var command = new CreateLegalCaseCommand("Corporate Merger", "M&A for Tech Corp", "Tech Corp Inc.");
            var cancellationToken = new CancellationToken();

            // Act
            var resultId = await _handler.Handle(command, cancellationToken);

            // Assert
            resultId.Should().NotBeEmpty();

            _repositoryMock.Verify(
                r => r.AddAsync(It.Is<LegalCase>(c => c.Title == command.Title && c.ClientName == command.ClientName), cancellationToken),
                Times.Once);

            _repositoryMock.Verify(
                r => r.SaveChangesAsync(cancellationToken),
                Times.Once);
        }
    }
}
