using MDR.Core.DomainObjects;

namespace MDR.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
}
