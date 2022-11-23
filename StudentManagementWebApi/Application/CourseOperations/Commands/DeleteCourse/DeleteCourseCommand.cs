using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.CourseOperations.Commands.DeleteCourse
{
    public class DeleteCourseCommand
    {
        public int CourseId {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;

        public DeleteCourseCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var course = _dbcontext.Courses.SingleOrDefault(x=> x.Id == CourseId);
            if(course is null)
                throw new InvalidOperationException("Silinecek kurs bulunamadı ...");
            
            _dbcontext.Courses.Remove(course);
            _dbcontext.SaveChanges();
        }
    }
}