using ManageCourses.Areas.Admin.Models;
using ManageCourses.Models;
using System.Xml.Linq;

namespace ManageCourses.Repository
{
    public class TrainerRepository : ITrainerRepository
    {
        public TrainerRepository(ManageCourseContext db)
        {
            Db = db;
        }

        public ManageCourseContext Db { get; }

        public int add(TrainerVM model)
        {
            trainer t = new trainer()
            {
                //creationDate = DateTime.Now,
                creationDate = model.creationDate,
                description = model.description,
                email = model.email,
                name = model.name,
                website = model.website
            };
            Db.trainers.Add(t);
            return Db.SaveChanges();
        }

        public int delete(int id)
        {
            trainer t = Db.trainers.Find(id);
            Db.Remove(t);
            return Db.SaveChanges();
        }

        public List<trainer> GetAll()
        {
            return Db.trainers.ToList();
        }

        public TrainerVM getByEmail(string email)
        {
            var t = Db.trainers.FirstOrDefault(t => t.email == email);
            if (t != null)
                return new TrainerVM() { email = email };
            return null;
        }

        public TrainerVM getById(int id)
        {
            trainer t = Db.trainers.Find(id);
            return new TrainerVM()
            {
                creationDate = t.creationDate,
                description = t.description,
                email = t.email,
                name = t.name,
                website = t.website,
                id = t.id
            };
        }

        public TrainerVM getByName(string name)
        {
            var t = Db.trainers.FirstOrDefault(t => t.name == name);
            if(t != null)
                return new TrainerVM() { name = name };
            return null;
        }

        public int update(int id, TrainerVM model)
        {
            trainer t = Db.trainers.Find(id);
            if(model.id == t.id)
            {
                t.email = model.email;
                t.website = model.website;
                t.description = model.description;
                t.creationDate = model.creationDate;
                t.name = model.name;
            }
            return -1;
        }
    }
}
