namespace ReCrut.Infrastructure.Test;

public class BsonHelperShould
{
    [Fact]
    public void SerializeAndDeserializeEvent()
    {
        var @event = new DumbEvent(Guid.NewGuid(), 1, DateTimeOffset.Now, "dumb");

        var serializedEvent = BsonHelper.ToBson(@event);

        var deserializedEvent = BsonHelper.FromBson<DumbEvent>(serializedEvent);

        deserializedEvent.Should().Be(@event);
    }

    private record DumbEvent(
        Guid AggregateId,
        int AggregateVersion,
        DateTimeOffset EventDate,
        string AggregateName) :
    Event(
        AggregateId,
        AggregateVersion,
        EventDate, 
        AggregateName);
}