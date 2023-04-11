using DataLayer.Enums;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;

public record CourseSectionInputDto(int TermId, int InstructorId, int CourseId);
