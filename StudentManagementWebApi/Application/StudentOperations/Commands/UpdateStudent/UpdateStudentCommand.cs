
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommand
    {
        private readonly IStudentManagementDbContext _dbcontext;
        
        public int StudentId{get; set;}
        public UpdateStudentModel Model{get; set;}
        
        public UpdateStudentCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

         public void Handle()
        {
            var student = _dbcontext.Students.SingleOrDefault(x=> x.Id == StudentId);
            if(student is null)
                throw new InvalidOperationException("Güncellenecek öğrenci bulunamadı ...");
            
            student.Name = Model.Name != default ? Model.Name : student.Name;
            student.SurName = Model.SurName != default ? Model.SurName : student.SurName;
            student.PhoneNumber = Model.PhoneNumber != default ? Model.PhoneNumber : student.PhoneNumber;
            student.Adress = Model.Adress != default ? Model.Adress : student.Adress;
            student.Email = Model.Email != default ? Model.Email : student.Email;
    
            _dbcontext.SaveChanges();
        }
    }
}