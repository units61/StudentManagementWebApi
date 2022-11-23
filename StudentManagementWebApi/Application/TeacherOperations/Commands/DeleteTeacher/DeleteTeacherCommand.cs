using StudentManagementWebApi.DBOperations;


namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand
    {
        public int TeacherId {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;

        public DeleteTeacherCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var teacher = _dbcontext.Teachers.SingleOrDefault(x=> x.Id == TeacherId);
            if(teacher is null)
                throw new InvalidOperationException("Silinecek öğrenci bulunamadı ...");
            
            _dbcontext.Teachers.Remove(teacher);
            _dbcontext.SaveChanges();
        }
    }
}