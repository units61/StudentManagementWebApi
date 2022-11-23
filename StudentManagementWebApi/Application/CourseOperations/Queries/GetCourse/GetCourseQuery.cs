using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.Application.CourseOperations.Queries
{
    public class GetCourseQuery
    {
        public readonly IStudentManagementDbContext _dbcontext;
        public readonly IMapper _mapper;

        public GetCourseQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

         public List<CoursesViewModel> Handle()
        {
            var courselist = _dbcontext.Courses.Include(i=> i.Teacher).Include(i=> i.StudentCourses).ThenInclude(t=> t.Student).OrderBy(x => x.Id).ToList<Course>();
            List<CoursesViewModel> vm = _mapper.Map<List<CoursesViewModel>>(courselist);
            return vm;
        }
    }
}