using AutoMapper;
using StudentManagementWebApi.DBOperations;
using TeacherManagementWebApi.Application.CourseOperations.TeacherModels;

namespace TeacherManagementWebApi.Application.TeacherOperations.Queries.GetDetailTeacher
{
    public class GetTeacherDetailQuery
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int TeacherId {get; set;}

        public GetTeacherDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public TeacherDetailViewModel Handle()
        {
            var teacher = _dbcontext.Teachers.Where(teacher=> teacher.Id == TeacherId).SingleOrDefault(); 
            if(teacher is null)
                throw new InvalidOperationException("Öğretmen bulunamadı ...");  
            TeacherDetailViewModel vm = _mapper.Map<TeacherDetailViewModel>(teacher);
            return vm;      
        }
    }
}