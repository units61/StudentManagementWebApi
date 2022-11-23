using AutoMapper;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.Application.CourseOperations.Commands.CreateCourse
{
    public class CreateCourseCommand
    {
        public CreateCourseModel Model {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateCourseCommand(IStudentManagementDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var course = _dbcontext.Courses.SingleOrDefault(x=> x.Name == Model.Name);
            if(course is not null)
                throw new InvalidOperationException("Kurs zaten mevcut ...");
            
            course = _mapper.Map<Course>(Model);
            
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();
        }
    }
}