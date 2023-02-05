using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAspMvcApplication.DataAccess
{
    public static class DataStorageFactory
    {
        public static IDataStorage Create()
        {
            return new DbStorage();
        }

    }
}