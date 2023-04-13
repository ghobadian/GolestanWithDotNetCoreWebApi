using DataLayer.Models.Entities;

namespace DataLayer.Repositories
{
    public interface ICourseRepository : ICrudRepository<Course>
    {
        public bool ExistsById(int id);
    }
}
