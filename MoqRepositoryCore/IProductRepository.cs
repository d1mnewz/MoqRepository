using System.Collections.Generic;

namespace MoqRepositoryCore
{
    public interface IRepository<T>
    {
        IList<T> FindAll<T>();

        T FindByName<T>(string productName);

        T FindById<T>(int productId);

        bool Save<T>(T target);
    }
}