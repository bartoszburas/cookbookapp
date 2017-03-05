using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseFactory : IDataAccessObjectFactory
    {
        private static DatabaseFactory instance;
        protected DatabaseFactory() { }

        public static IDataAccessObjectFactory GetInstance()
        {
            if (instance == null)
                instance = new DatabaseFactory();
            return instance;
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["cookbookdbEntities"].ConnectionString;
        }

        public IDataAccessObject GetDao()
        {
            return new Database();
        }
    }
}
