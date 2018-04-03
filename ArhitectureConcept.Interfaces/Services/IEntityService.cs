using System.Collections.Generic;

namespace ArhitectureConcept.Interfaces.Services
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        bool Remove(T item);
    }
}
