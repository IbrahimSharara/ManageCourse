namespace ManageCourses.Repository
{
    public interface IAdminRepository
    {
        bool Login(string email, string password);
        bool ChangePassword(string email, string password);
        bool ForgitPassword(string email);
    }
}
