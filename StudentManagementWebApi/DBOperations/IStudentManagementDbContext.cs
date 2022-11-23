

using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.DBOperations
{
    public interface IStudentManagementDbContext
    {
        public DbSet<Course> Courses {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<StudentCourse> StudentCourses {get; set;}
        public DbSet<User> Users {get; set;}
       

        int SaveChanges();
       
    }
}