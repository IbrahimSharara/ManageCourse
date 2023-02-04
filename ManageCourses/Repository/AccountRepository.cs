using ManageCourses.Models;

namespace ManageCourses.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public ManageCourseContext Db { get; }
        public AccountRepository(ManageCourseContext db)
        {
            Db = db;
        }

        public bool Login(string email, string password)
        {
            return Db.Admins.Where(a => a.email == email && a.password == password).Any();
        }
    }
}
