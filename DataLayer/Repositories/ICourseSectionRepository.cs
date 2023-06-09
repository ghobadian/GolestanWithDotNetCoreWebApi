﻿using DataLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Entities.Users;

namespace DataLayer.Repositories
{
    public interface ICourseSectionRepository : ICrudRepository<CourseSection>
    {
        public IEnumerable<CourseSection> FindByTerm(Term term);
        public bool ExistsByIdAndTerm(int id, Term term);
        public IEnumerable<CourseSection> FindAllByTermIdAndInstructorUsernameAndCourseTitle(int termId, string username, string courseTitle, int pageNumber, int pageSize);
        public IEnumerable<CourseSection> FindByInstructorId(int instructorId);

    }
}
