
using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.Users;
using DataLayer.Repositories;

namespace Golestan.Services;
public class InstructorService {
    private readonly IInstructorRepository instructorRepository;
    private readonly ICourseSectionRegistrationRepository csrRepository;

    public InstructorService(IInstructorRepository instructorRepository,
        ICourseSectionRegistrationRepository csrRepository)
    {
        this.instructorRepository = instructorRepository;
        this.csrRepository = csrRepository;
    }

    public IEnumerable<Instructor> List(/*int page, int number*/) => instructorRepository.GetAll();

    public Instructor Read(int instructorId) => instructorRepository.GetById(instructorId);

    public Instructor Update(Rank rank, int instructorId)
    {
        Instructor instructor = instructorRepository.GetById(instructorId);
        instructor.Rank = rank;//todo check if null or rank is the same as before
        instructorRepository.Update(instructor);
        instructorRepository.Save();
        return instructor;
    }

    public void Delete(int instructorId)
    {

        //List<CourseSection> courseSectionsOfInstructor = repo.findCourseSectionByInstructorId(instructorId);
        //courseSectionsOfInstructor.forEach(cs -> cs.setInstructor(null));
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
}
