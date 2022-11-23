using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.CourseOperations.Queries
{
    public class GetCourseDetailQuery
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int CourseId {get; set;}

        public GetCourseDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public CourseDetailViewModel Handle()
        {
            var course = _dbcontext.Courses.Include(i=> i.Teacher).Include(i=> i.StudentCourses).ThenInclude(t=> t.Student).Where(course=> course.Id == CourseId).SingleOrDefault(); 
            if(course is null)
                throw new InvalidOperationException("Kurs bulunamadı ...");  
            CourseDetailViewModel vm = _mapper.Map<CourseDetailViewModel>(course);
            return vm;      
        }
    }
}