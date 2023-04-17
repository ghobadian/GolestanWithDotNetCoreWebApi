using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Entities;
using PagedList;

namespace DataLayer.Services;

public class TermRepository : CrudRepository<Term>, ITermRepository
{
    public TermRepository(LoliBase db) : base(db) {}

    public IEnumerable<Term> GetAll() => entities;

    public bool ExistsByTitle(string title) => entities.Any(term => term.Title == title);
}

