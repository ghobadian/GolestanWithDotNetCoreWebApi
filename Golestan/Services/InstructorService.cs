
using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Golestan.Services.Interfaces;
using Golestan.Utils;

namespace Golestan.Services;
public class InstructorService : IInstructorService 
{
    private readonly IInstructorRepository instructorRepository;
    private readonly ICourseSectionRegistrationRepository csrRepository;
    private readonly IUserService userService;

    public InstructorService(IInstructorRepository instructorRepository,
        ICourseSectionRegistrationRepository csrRepository,
        IUserService userService)
    {
        this.instructorRepository = instructorRepository;
        this.csrRepository = csrRepository;
        this.userService = userService;
    }

    public IEnumerable<InstructorOutputDto> List(/*int page, int number*/) => instructorRepository.GetAll().Select(instructor => instructor.OutputDto());
    public InstructorOutputDto Create(InstructorInputDto dto)
    {
        var instructor = new Instructor();
        userService.CreateUserAspects(instructor, dto);
        instructorRepository.Insert(instructor);
        instructorRepository.Save();
        return instructor.OutputDto();
    }

    public InstructorOutputDto Read(int instructorId) => instructorRepository.GetById(instructorId).OutputDto();
    public InstructorOutputDto Update(int id, InstructorInputDto dto)
    {
        var instructor = instructorRepository.GetById(id);
        userService.CreateUserAspects(instructor, dto);
        instructorRepository.Update(instructor);
        instructorRepository.Save();
        return instructor.OutputDto();
    }

    public void Delete(int instructorId)
    {

        //List<CourseSection> courseSectionsOfInstructor = repo.findCourseSectionByInstructorId(instructorId);
        //courseSectionsOfInstructor.forEach(service -> service.setInstructor(null));
        //todo test delete cascading 
        instructorRepository.Delete(instructorId);
        //log.info("Instructor with id " + instructorId + " Deleted");
    }

    public CourseSectionRegistration GiveMark(int courseSectionId, int studentId, double score)
    {
        var csr = csrRepository.FindByCourseSectionIdAndStudentId(courseSectionId, studentId);
        csr.Score = score;
        csrRepository.Update(csr);
        csrRepository.Save();
        return csr;
    }

    public List<CourseSectionRegistration> GiveMultipleMarks(int courseSectionId, Dictionary<int, double> idsAndScoresJson) 
    {
        var response = new List<CourseSectionRegistration>();
        foreach (var (id, score) in idsAndScoresJson)
        {
            response.Add(GiveMark(courseSectionId, id, score));
        }
        return response;
    }

    public TokenOutputDto Login(string username, string password)
    {
        checkAuthority(username, password);
        var token = TokenGenerator.GenerateToken(Role.INSTRUCTOR, username);
        TokenRepository.Insert(token);
        return token.OutputDto();
    }

    private void checkAuthority(string username, string password)
    {
        if (!instructorRepository.ExistsByUsername(username)) throw new UsernameOrPasswordInvalidException();
        var instructor = instructorRepository.FindByUsername(username);
        if (instructor.Password != PasswordEncoder.Encode(password)) throw new UsernameOrPasswordInvalidException();
        if (TokenRepository.ExistsByUsername(username)) throw new ReLoginException();
    }
}
