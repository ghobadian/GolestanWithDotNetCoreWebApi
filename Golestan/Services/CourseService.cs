using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        this.courseRepository = courseRepository;
    }

    public IEnumerable<Course> List()
    {
        return courseRepository.GetAll();
    }

    //public List<Course> List(int page, int number)
    //{
    //    return repo.GetAll(page, number);
    //}

    public Course Create(int units, string title)
    {
        Course course = new() { Units = units, Title = title };
        //log.info("Course " + course.getTitle() + " created");
        courseRepository.Insert(course);
        courseRepository.Save();
        return course;
    }

    public Course Read(int id)
    {
        return courseRepository.GetById(id);
    }

    public Course Update(int courseId, string title, int? units)
    {
        Course course = courseRepository.GetById(courseId);
        UpdateTitle(title, course);
        UpdateUnits(units, course);
        var updatedCourse = courseRepository.Update(course);
        courseRepository.Save();
        return updatedCourse;
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
        //log.info("Course " + course.getTitle() + " Deleted");
    }
}

