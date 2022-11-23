
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.DBOperations
{
    public class StudentManagementDbContext : DbContext, IStudentManagementDbContext
    {
        
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options) : base(options)
        {}
        public DbSet<Course> Courses {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<StudentCourse> StudentCourses {get; set;}
       

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<StudentCourse>()
            .HasKey(x => new {x.StudentId, x.CourseId});
        }
    }
}