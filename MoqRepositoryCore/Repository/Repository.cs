using System.Collections.Generic;

namespace MoqRepositorySample.Data.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public IEnumerable<T> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public T FindByName(string productName)
        {
            throw new System.NotImplementedException();
        }

        public T FindById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(T target)
        {
            throw new System.NotImplementedException();
        }

    }
}



