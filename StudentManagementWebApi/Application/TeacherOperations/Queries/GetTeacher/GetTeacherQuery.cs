
using AutoMapper;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TeacherManagementWebApi.Application.CourseOperations.TeacherModels;


namespace TeacherManagementWebApi.Application.TeacherOperations.Queries.GetTeacher
{
    public class GetTeacherQuery
    {
        public readonly IStudentManagementDbContext _dbcontext;
        public readonly IMapper _mapper;

        public GetTeacherQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

         public List<TeachersViewModel> Handle()
        {
            var teacherlist = _dbcontext.Teachers.OrderBy(x => x.Id).ToList<Teacher>();
            List<TeachersViewModel> vm = _mapper.Map<List<TeachersViewModel>>(teacherlist);
            return vm;
        }
    }
}