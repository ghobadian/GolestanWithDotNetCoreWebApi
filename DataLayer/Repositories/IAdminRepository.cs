using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories;
public interface IAdminRepository : ICrudRepository<Admin>
{
    Admin FindByUsername(string username);
    bool ExistsByPhone(string phone);
    bool ExistsByUsername(string username);
}

