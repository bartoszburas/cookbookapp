namespace DataAccessLayer
{
    public interface IDataAccessObjectFactory
    {
        IDataAccessObject GetDao();
        string GetConnectionString();
    }
}