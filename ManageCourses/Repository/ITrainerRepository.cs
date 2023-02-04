using ManageCourses.Areas.Admin.Models;
using ManageCourses.Models;

namespace ManageCourses.Repository
{
    public interface ITrainerRepository
    {
        int add(TrainerVM model);
        int delete(int id);
        int update(int id, TrainerVM model);
        List<trainer> GetAll();
        TrainerVM getById(int id);
        TrainerVM getByName(string name);
        TrainerVM getByEmail(string email);
    }
}
