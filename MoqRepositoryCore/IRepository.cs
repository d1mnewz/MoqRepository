using System.Collections.Generic;

namespace MoqRepositoryCore.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();

        T FindByName(string productName);

        T FindById(int productId);

        bool Save(T target);
    }
}