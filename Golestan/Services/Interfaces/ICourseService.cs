using DataLayer.Models;

namespace Golestan.Services.Interfaces;
public interface ICourseService
{
    IEnumerable<Course> List();
    Course Create(int units, string title);
    Course Read(int courseId);
    Course Update(int id, string title, int? units);
    void Delete(int courseId);

}

