using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services;

public class GeneralRepository<T>/* where T : class, new()*/
{
    protected LoliBase db;

    public GeneralRepository(LoliBase db)
    {
        this.db = db;
    }

    public void Activate(int id)
    {
        
    }

    public void Save()
    {
        db.SaveChanges();
    }


}