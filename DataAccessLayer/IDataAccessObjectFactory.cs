namespace DataAccessLayer
{
    public interface IDataAccessObjectFactory
    {
        IDataAccessObject GetDao();
    }
}