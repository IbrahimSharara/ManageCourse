using ManageCourses.Areas.Admin.Models;
using ManageCourses.Models;

namespace ManageCourses.Repository
{
    public interface ICategoryRepository
    {
        int add(CategoryVM model);
        int delete(int id);
        int update(int id, CategoryVM model);
        List<category> GetAll();
        CategoryVM getById(int id);
        CategoryVM getByName(string name);
    }
}
