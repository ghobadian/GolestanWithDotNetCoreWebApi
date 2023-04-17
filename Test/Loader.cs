
//using System.Net.Http.Json;
//using DataLayer.Contexts;
//using DataLayer.Enums;
//using DataLayer.Models.DTOs;
//using DataLayer.Models.DTOs.Input;
//using DataLayer.Models.Entities;
//using DataLayer.Models.Entities.Users;
//using DataLayer.Services;
//using Golestan.Utils;
//using Microsoft.AspNetCore.Mvc.Formatters;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;

//public static class Loader
//{
//    private static LoliBase _db;
//    private static HttpClient _httpClient;

//    public static void LoadData(LoliBase db, HttpClient httpClient)
//    {
//        _db = db;
//        _httpClient = httpClient;
//        loadAdmin();
//        createStudents();
//        createInstructorUsers();
//        adminLogin();
//        activateStudents();
//        giveInstructorRoles();
//        createTerms();
//        createCourse();
//        createCourseSection();
//    }

//    private static void adminLogin()
//    {
//        _httpClient.DefaultRequestHeaders.Add("username", "admin");
//        _httpClient.DefaultRequestHeaders.Add("password", "admin");
//        var response = _httpClient.PostAsync("/admin/create", null).Result;
//        var responseContent = response.Content;
//    }

//    private static void loadAdmin()
//    {
//        var admin = new Admin()
//        {
//            Active = true, Name = "admin", NationalId = "5410221919", Password = PasswordEncoder.Encode("admin"),
//            PhoneNumber = "09303191231", UserName = "admin"
//        };
//        _db.Admins.Add(admin);
//        _db.SaveChanges();//todo save later
//        TokenRepository.Insert(new Token("admin", DateTime.MaxValue, Role.ADMIN, "admin"));
//    }

//    private static void createCourseSection() {
//        for(int i=0;i<10;i++) {
//            Course course = _db.Courses.ToList()[i];
//            Instructor instructor = _db.Instructors.ToList()[i];
//            Term term = _db.Terms.ToList()[i];
//            string temp = "instructor" + i;
//            TokenRepository.Insert(new Token(temp, DateTime.MaxValue, Role.INSTRUCTOR, temp));
//            _httpClient.DefaultRequestHeaders.Add("token", temp);
//            Dictionary<string, string?> queryParams = new Dictionary<string, string?>
//            {
//                ["courseId"] = course.Id.ToString(),
//                ["instructorId"] = instructor.Id.ToString(),
//                ["termId"] = term.Id.ToString(),
//            };

//            _httpClient.PostAsync(QueryHelpers.AddQueryString("/coursesection/create", queryParams),null);

//            var courseSection = _db.CourseSections.ToList()[i];

//            Assert.Equal(courseSection.Course, course);
//            Assert.Equal(courseSection.Instructor, instructor);
//            Assert.Equal(courseSection.Term, term);
//        }
//    }

//    private static void createCourse() {
//        //for(int i=0;i<10;i++) {
//        //    mockMvc.perform(post("/management/courses")
//        //            .header("token", "admin")
//        //            .param("title", "BodyBuilding" + i)
//        //            .param("units", String.valueOf(5)));
//        //}
//        //Course course = repo.findAllCourses().get(0);
//        //assertEquals(course.getTitle(), "BodyBuilding0");
//        //assertEquals(course.getUnits(), 5);
//    }

//    private static void createTerms() {
//        //for(int i=3;i<13;i++) {
//        //    mockMvc.perform(post("/management/terms")
//        //            .header("token", "admin")
//        //            .param("title", "400" + i)
//        //            .param("open", String.valueOf(true)));
//        //}

//        //Term term = repo.findAllTerms().get(0);
//        //assertEquals(term.getTitle(), "4003");
//    }

//    private static void giveInstructorRoles()
//    {
//        //for (int i = 0; i < 10; i++)
//        //{
//        //    User instructorUser = repo.findUserByUsername("instructor" + i);
//        //    JSONObject requestBody = new JSONObject();
//        //    requestBody.put("role", "instructor");
//        //    requestBody.put("rank", "FULL");
//        //    mockMvc.perform(post("/management/users/{userId}/modifyRole", instructorUser.getId())
//        //            .header("token", "admin")
//        //            .contentType(MediaType.APPLICATION_JSON).content(requestBody.toString()));
//        //}
//        //Instructor instructor = repo.findAllInstructors().get(0);
//        //assertEquals(instructor.getRank(), Rank.FULL);
//    }

//    private static void activateStudents()
//    {
//        //for (int i = 0; i < 10; i++)
//        //{

//        //    User studentUser = repo.findUserByUsername("student" + i);
//        //    JSONObject requestBody = new JSONObject();
//        //    requestBody.put("role", "student");
//        //    requestBody.put("degree", "BS");
//        //    mockMvc.perform(post("/management/users/{userId}/modifyRole", studentUser.getId())
//        //            .header("token", "admin")
//        //            .contentType(MediaType.APPLICATION_JSON)
//        //            .content(String.valueOf(requestBody))
//        //            .accept(MediaType.APPLICATION_JSON));
//        //}
//        //StudentId student = repo.findStudentByUsername("student0");
//        //assertEquals(student.getDegree(), Degree.BS);
//    }

//    private static void createInstructorUsers()
//    {
//        for(int i=0;i<10;i++) {
//            string temp = "instructor" + i;
//            string body = JsonConvert.SerializeObject(new InstructorInputDto(temp, temp + "A", temp, "0903156879" + i,
//                "546879412" + i, Rank.FULL));
//            _httpClient.PostAsJsonAsync("/instructor/create", body);
//            TokenRepository.Insert(new Token(temp, DateTime.MaxValue, Role.INSTRUCTOR, temp));
//        }
//        var instructor = _db.Instructors.Single(instructor => instructor.UserName == "instructor3");
//        Assert.Equal(instructor.Password, PasswordEncoder.Encode("instructor3A"));
//        Assert.Equal(10, _db.Instructors.Count());
//    }

//    private static void createStudents()
//    {
//        _httpClient.DefaultRequestHeaders.Add("token", "admin");
//        for(int i=0;i<10;i++) {
//            var temp = "student"+ i;
//            var student = new StudentInputDto(temp, temp + "A", temp, "0901254125" + i,
//                "541254687" + i, Degree.BS);
////var body = JsonConvert.SerializeObject(student);
//var response = _httpClient.PostAsJsonAsync("/student/create", student);
//            var readAsStringAsync = response.Result.Content.ToString();
//            TokenRepository.Insert(new Token(temp, DateTime.MaxValue, Role.STUDENT, temp));
//        }

//        Assert.Equal(10, _db.Students.Count());
//    }
//}
