using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using StudentManagementWebApi.DBOperations;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public StudentManagementDbContext Context {get; set;}
        public IMapper Mapper {get; set;}

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<StudentManagementDbContext>().UseInMemoryDatabase(databaseName:"MovieStoreTestDB").Options;
            Context = new StudentManagementDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddCourses();
            Context.AddStudentCourses();
            Context.AddStudents();
            Context.AddTeachers();
            Context.AddUsers();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
            
        }
    }
}