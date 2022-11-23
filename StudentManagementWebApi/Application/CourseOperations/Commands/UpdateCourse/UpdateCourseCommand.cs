
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommand
    {
        private readonly IStudentManagementDbContext _dbcontext;
        
        public int CourseId{get; set;}
        public UpdateCourseModel Model{get; set;}
        
        public UpdateCourseCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

         public void Handle()
        {
            var course = _dbcontext.Courses.SingleOrDefault(x=> x.Id == CourseId);
            if(course is null)
                throw new InvalidOperationException("Güncellenecek kurs bulunamadı ...");
            
            course.Name = Model.Name != default ? Model.Name : course.Name;
            course.Price = Model.Price != default ? Model.Price : course.Price;
            course.TimeDuration = Model.TimeDuration != default ? Model.TimeDuration : course.TimeDuration;
    
            _dbcontext.SaveChanges();
        }
    }
}