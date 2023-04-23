namespace ReCrut.Application.Test;

public class CommandHandlerShould
{
    [Fact]
    public void ReturnHandleResultErrorWhenHandleUnknowCommand()
    {
        // Given
        var handler = BuildHandler();
        var command = new UnknowCommand(Guid.NewGuid());

        // When
        var handleResult = handler.Handle(command);

        // Then
        handleResult.Should().BeOfType<HandleResultError>();
    }

    [Fact]
    public void ReturnHandleResultOkWhenHandleCommand()
    {
        // Given
        var command = new CreerCandidatCommand(
            Guid.NewGuid(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            DateOnly.MinValue,
            CandidatStatus.CommercialAContacter);

        var handler = BuildHandler();

        // When
        var handleResult = handler.Handle(command);

        // Then
        handleResult.Should().BeOfType<HandleResultOk>();
    }

    [Fact]
    public void PublishAndSaveEventWhenHandleCommand()
    {
        // Given
        var command = new CreerCandidatCommand(
            Guid.NewGuid(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            DateOnly.MinValue,
            CandidatStatus.CommercialAContacter);

        var fakeEventRepository = new FakeEventRepository();
        var fakeEventPublisher = new FakeEventPublisher();

        var handler = BuildHandler(
            fakeEventRepository: fakeEventRepository,
            fakeEventPublisher: fakeEventPublisher);

        // When
        _ = handler.Handle(command);

        // Then
        fakeEventPublisher.PublishedEvents.Should().HaveCount(1);
        fakeEventRepository.SavedEvents.Should().HaveCount(1);
    }

    private record UnknowCommand(Guid AggregateId) : Command(AggregateId);

    private static CommandHandler BuildHandler(
            FakeDateTimeProvider? fakeDateTimeProvider = null,
            FakeStateRepository? fakeStateRepository = null,
            FakeEventRepository? fakeEventRepository = null,
            FakeEventPublisher? fakeEventPublisher = null)
        => new(
            new FakeLogger<CommandHandler>(),
            fakeDateTimeProvider ?? new FakeDateTimeProvider(DateTimeOffset.Now),
            fakeStateRepository ?? new FakeStateRepository(),
            fakeEventRepository ?? new FakeEventRepository(),
            fakeEventPublisher ?? new FakeEventPublisher());
}