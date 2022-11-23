using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace TestSetup
{
    public static class StudentCourses
    {
        public static void AddStudentCourses(this StudentManagementDbContext context)
        {
            context.StudentCourses.AddRange
            (
                new StudentCourse{ StudentId = 1, CourseId = 1},
                new StudentCourse{ StudentId = 1, CourseId = 3},
                new StudentCourse{ StudentId = 2, CourseId = 1},
                new StudentCourse{ StudentId = 2, CourseId = 2},
                new StudentCourse{ StudentId = 2, CourseId = 3},
                new StudentCourse{ StudentId = 2, CourseId = 4},
                new StudentCourse{ StudentId = 3, CourseId = 2},
                new StudentCourse{ StudentId = 3, CourseId = 4}       
            );
        }
    }
}