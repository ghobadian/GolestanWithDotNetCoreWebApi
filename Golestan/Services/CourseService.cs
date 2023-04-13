using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository courseRepository;
    private readonly ILogger<Course> logger;

    public CourseService(ICourseRepository courseRepository, ILogger<Course> logger)
    {
        this.courseRepository = courseRepository;
        this.logger = logger;
    }

    public IEnumerable<CourseOutputDto> List(int pageNumber, int pageSize) => courseRepository.GetAll(pageNumber, pageSize).Select(course => course.OutputDto());

    public CourseOutputDto Create(CourseInputDto dto)
    {
        Course course = new() { Units = dto.Units.Value, Title = dto.Title};
        logger.LogInformation("Course \" + course.getTitle() + \" created");
        courseRepository.Insert(course);
        courseRepository.Save();
        return course.OutputDto();
    }

    public CourseOutputDto Read(int id) => courseRepository.GetById(id).OutputDto();

    public CourseOutputDto Update(int id, CourseInputDto dto)
    {
        Course course = courseRepository.GetById(id);
        UpdateTitle(dto.Title, course);
        UpdateUnits(dto.Units, course);
        var updatedCourse = courseRepository.Update(course);
        courseRepository.Save();
        return updatedCourse.OutputDto();
    }

    private static void UpdateUnits(int? units, Course course)
    {
        if (units != null)
        {
            course.Units = units.Value;
        }
    }

    private static void UpdateTitle(string? title, Course course)
    {
        if (title != null)
        {
            course.Title = title;
        }
    }

    public void Delete(int courseId)
    {
        courseRepository.Delete(courseId);
        courseRepository.Save();
        logger.LogInformation("Course \" + course.getTitle() + \" Deleted");
    }
}

