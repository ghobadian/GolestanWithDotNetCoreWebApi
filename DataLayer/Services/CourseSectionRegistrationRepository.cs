using DataLayer.Repositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;

namespace DataLayer.Services
{
    public class CourseSectionRegistrationRepository : AllInOneRepository<CourseSectionRegistration>
    {
        public CourseSectionRegistrationRepository(LoliBase db) : base(db) { }

        public override IEnumerable<CourseSectionRegistration> GetAll()
        {
            return db.CourseSectionRegistrations;
        }

        public override CourseSectionRegistration GetById(int id)
        {
            return db.CourseSectionRegistrations.Single(entity => entity.Id == id);
        }

        public override bool Insert(CourseSectionRegistration entity)
        {
            try
            {
                db.CourseSectionRegistrations.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
