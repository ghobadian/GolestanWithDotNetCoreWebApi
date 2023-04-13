using DataLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ITermRepository : ICrudRepository<Term>
    {
        IEnumerable<Term> GetAll();
        bool ExistsByTitle(string title);
        bool ExistsById(int id);
    }
}
