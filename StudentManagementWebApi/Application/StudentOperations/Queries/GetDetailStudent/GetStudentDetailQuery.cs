using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Application.CourseOperations.StudentModels;
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.StudentOperations.Queries.GetDetailStudent
{
    public class GetStudentDetailQuery
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int StudentId {get; set;}

        public GetStudentDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public StudentDetailViewModel Handle()
        {
            var student = _dbcontext.Students.Include(i=> i.StudentCourses).ThenInclude(t=> t.Course).Where(student=> student.Id == StudentId).SingleOrDefault(); 
            if(student is null)
                throw new InvalidOperationException("Öğrenci bulunamadı ...");  
            StudentDetailViewModel vm = _mapper.Map<StudentDetailViewModel>(student);
            return vm;      
        }
    }
}