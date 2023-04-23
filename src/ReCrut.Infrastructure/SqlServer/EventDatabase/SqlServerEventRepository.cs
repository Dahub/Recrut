using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Infrastructure.SqlServer.EventDatabase;

public class SqlServerEventRepository : IEventRepository
{
    private readonly EventDbContext _context;

    public SqlServerEventRepository(EventDbContext dbContext) => _context = dbContext;

    public IOrderedEnumerable<Event> GetAggregateEvents(Guid aggregateId) =>
        _context.Events.Where(e => e.AggregateId.Equals(aggregateId)).ToEvent().OrderBy(e => e.AggregateVersion);

    public void Save(Event @event)
    {
        _context.Events.Add(@event.ToEfEntity());
        _context.SaveChanges();
    }
}
