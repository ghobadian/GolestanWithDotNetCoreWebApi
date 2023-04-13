using DataLayer.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories;
public interface IAdminRepository : IUserRepository<Admin>
{
    
}

