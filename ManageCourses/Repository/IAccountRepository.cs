namespace ManageCourses.Repository
{
    public interface IAccountRepository
    {
        bool Login(string username, string password);

    }
}
