namespace DataAccessLayer
{
    // Abstract factory is a little bit overkill here, but let's just say that
    // we are future proofing in case we need more DAOs
    public interface IDataAccessObjectFactory
    {
        IDataAccessObject GetDao();
        string GetConnectionString();
    }
}