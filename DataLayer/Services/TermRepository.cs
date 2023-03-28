using DataLayer.Repositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Users;

namespace DataLayer.Services
{
    public class TermRepository : AllInOneRepository<Term>
    {
        public TermRepository(LoliBase db) : base(db) { }

        public override IEnumerable<Term> GetAll()
        {
            return db.Terms;
        }

        public override Term GetById(int id)
        {
            return db.Terms.Single(entity => entity.Id == id);
        }

        public override bool Insert(Term entity)
        {
            try
            {
                db.Terms.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistsByTitle(string title) => db.Terms.Any(entity => entity.Title == title);
    }
}
