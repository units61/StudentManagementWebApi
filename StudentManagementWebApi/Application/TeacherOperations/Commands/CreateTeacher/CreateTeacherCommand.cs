using AutoMapper;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;

namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.CreateTeacher
{
    public class CreateTeacherCommand
    {
        public CreateTeacherModel Model {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateTeacherCommand(IStudentManagementDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var teacher = _dbcontext.Teachers.SingleOrDefault(x=> x.Name == Model.Name && x.SurName == Model.SurName);
            if(teacher is not null)
                throw new InvalidOperationException("Öğretmen zaten mevcut ...");
            
            teacher = _mapper.Map<Teacher>(Model);
            
            _dbcontext.Teachers.Add(teacher);
            _dbcontext.SaveChanges();
        }
    }
}