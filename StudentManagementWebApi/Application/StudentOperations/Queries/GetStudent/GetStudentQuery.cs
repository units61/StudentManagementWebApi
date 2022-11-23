using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Application.CourseOperations.StudentModels;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.Application.StudentOperations.Queries.GetStudent
{
    public class GetStudentQuery
    {
        public readonly IStudentManagementDbContext _dbcontext;
        public readonly IMapper _mapper;

        public GetStudentQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

         public List<StudentsViewModel> Handle()
        {
            var studentlist = _dbcontext.Students.Include(i=> i.StudentCourses).ThenInclude(t=> t.Course).OrderBy(x => x.Id).ToList<Student>();
            List<StudentsViewModel> vm = _mapper.Map<List<StudentsViewModel>>(studentlist);
            return vm;
        }
    }
}