using DataLayer.Models;
using DataLayer.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IInstructorRepository : ICrudRepository<Instructor>
    {
        bool ExistsById(int id);
        bool ExistsByUsername(string username);
        Instructor FindByUsername(string username);
    }
}
