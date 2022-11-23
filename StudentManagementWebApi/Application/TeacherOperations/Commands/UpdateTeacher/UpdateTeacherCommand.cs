
using StudentManagementWebApi.DBOperations;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;

namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand
    {
        private readonly IStudentManagementDbContext _dbcontext;
        
        public int TeacherId{get; set;}
        public UpdateTeacherModel Model{get; set;}
        
        public UpdateTeacherCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

         public void Handle()
        {
            var teacher = _dbcontext.Teachers.SingleOrDefault(x=> x.Id == TeacherId);
            if(teacher is null)
                throw new InvalidOperationException("Güncellenecek öğretmen bulunamadı ...");
            
            teacher.Name = Model.Name != default ? Model.Name : teacher.Name;
            teacher.SurName = Model.SurName != default ? Model.SurName : teacher.SurName;
            teacher.Qulification = Model.Qulification != default ? Model.Qulification : teacher.Qulification;
    
            _dbcontext.SaveChanges();
        }
    }
}