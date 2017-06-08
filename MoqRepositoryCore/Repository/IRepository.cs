using System.Collections.Generic;

namespace MoqRepositorySample.Data.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();

        T FindByName(string productName);

        T FindById(int productId);

        bool Save(T target);
    }
}