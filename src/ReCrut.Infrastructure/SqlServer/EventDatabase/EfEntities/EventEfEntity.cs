namespace ReCrut.Infrastructure.SqlServer.EventDatabase.EfEntities;

internal class EventEfEntity
{
    public EventEfEntity()
    {
        AggregateName = string.Empty;
        EventName = string.Empty;
        EventDatas = Array.Empty<byte>();
    }

    public Guid Id { get; set; }

    public Guid AggregateId { get; set; }

    public string AggregateName { get; set; }

    public int Version { get; set; }

    public string EventName { get; set; }

    public DateTime TimeStamp { get; set; }

    public byte[] EventDatas { get; set; }
}
