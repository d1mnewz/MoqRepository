using System;
using System.Collections.Generic;

namespace MoqRepositoryCore
{
    public class Repository<T> : IRepository<T>
    {
        #region IRepository Members

        public IList<T> FindAll<T>()
        {
            // Your database code here, whether it is linq, or ADO.Net, or something else
            // That actually fetches all the Products from a database and creates a list
            throw new System.NotImplementedException();
        }

        public T FindByName<T>(string productName)
        {
            // Your database code here, whether it is linq, or ADO.Net, or something else
            // That actually fetches a Product from a database, using the supplied parameter
            throw new System.NotImplementedException();
        }

        public T FindById<T>(int productId)
        {
            // Your database code here, whether it is linq, or ADO.Net, or something else
            // That actually fetches a Product from a database, using the supplied parameter
            throw new System.NotImplementedException();
        }

        public bool Save<T>(T target)
        {
            // Your database code here, whether it is linq, or ADO.Net, or something else
            // That actually saves a Product to a database (insert or update), using the supplied parameter
            throw new System.NotImplementedException();
        }

        #endregion
    }
}



