using AutoMapper;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommand
    {
        public CreateStudentModel Model {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateStudentCommand(IStudentManagementDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var student = _dbcontext.Students.SingleOrDefault(x=> x.Name == Model.Name && x.SurName == Model.SurName);
            if(student is not null)
                throw new InvalidOperationException("Öğrenci zaten mevcut ...");
            
            student = _mapper.Map<Student>(Model);
            
            _dbcontext.Students.Add(student);
            _dbcontext.SaveChanges();
        }
    }
}