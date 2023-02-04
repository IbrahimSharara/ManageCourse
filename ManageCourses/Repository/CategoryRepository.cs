using ManageCourses.Areas.Admin.Models;
using ManageCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageCourses.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository(ManageCourseContext db)
        {
            Db = db;
        }

        public ManageCourseContext Db { get; }

        public int add(CategoryVM model)
        {
            category c = new category()
            {
                name = model.name,
                parentId = model.parentId
            };
            Db.categories.Add(c);
            return Db.SaveChanges();
        }

        public int delete(int id)
        {
            category c = Db.categories.Find(id);
            Db.Remove(c);
            return Db.SaveChanges();
        }

        public List<category> GetAll()
        {
            return Db.categories.Include(s => s.parent).ToList();
        }

        public CategoryVM getById(int id)
        {
            category c = Db.categories.Find(id);
            if (c == null)
                return null;
            return new CategoryVM() { name = c.name, parentId = c.parentId, id = c.id };
        }

        public CategoryVM getByName(string name)
        {
            category c = Db.categories.SingleOrDefault(c => c.name == name);
            if(c == null )
                return null;
            return new CategoryVM() { name = c.name, parentId = c.parentId, id = c.id };
                
        }

        public int update(int id, CategoryVM model)
        {
            category c = Db.categories.Find(id);
            if(c.id == model.id)
            {
                c.name = model.name;
                c.parentId = model.parentId;
            }
            return Db.SaveChanges();
        }
    }
}
