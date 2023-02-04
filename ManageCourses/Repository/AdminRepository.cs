using ManageCourses.Models;

namespace ManageCourses.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public AdminRepository(ManageCourseContext db)
        {
            Db = db;
        }

        public ManageCourseContext Db { get; }

        public bool ChangePassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool ForgitPassword(string email)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            return Db.Admins.Where(a => a.email == email && a.password == password).Any();
        }
    }
}
