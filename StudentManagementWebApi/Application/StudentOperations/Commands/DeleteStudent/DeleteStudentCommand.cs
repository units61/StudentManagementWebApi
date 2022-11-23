using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommand
    {
        public int StudentId {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;

        public DeleteStudentCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var student = _dbcontext.Students.SingleOrDefault(x=> x.Id == StudentId);
            if(student is null)
                throw new InvalidOperationException("Silinecek öğrenci bulunamadı ...");
            
            _dbcontext.Students.Remove(student);
            _dbcontext.SaveChanges();
        }
    }
}