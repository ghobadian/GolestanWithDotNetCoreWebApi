using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ITermRepository : IDisposable
    {
        IEnumerable<Term> GetAll();
        Term GetById(int id);
        Term Insert(Term entity);
        Term Update(Term entity);
        bool Delete(int id);
        bool Delete(Term entity);
        void Save();
        void Dispose();
        bool ExistsByTitle(string title);
        public bool ExistsById(int id);
    }
}
