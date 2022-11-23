
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWebApi.Application.CourseOperations.Commands.CreateCourse;
using StudentManagementWebApi.Application.CourseOperations.Commands.DeleteCourse;
using StudentManagementWebApi.Application.CourseOperations.Commands.UpdateCourse;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.Application.CourseOperations.Queries;
using StudentManagementWebApi.Application.CourseOperations.Queries.GetDetailCourse;
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class CourseController : ControllerBase
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CourseController(IStudentManagementDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _dbcontext = context;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetCourse()
        {
           GetCourseQuery query = new GetCourseQuery(_dbcontext, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CourseDetailViewModel result;
            GetCourseDetailQuery query = new GetCourseDetailQuery(_dbcontext, _mapper);
            query.CourseId= id;
            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] CreateCourseModel newCourse)
        {
            CreateCourseCommand command = new CreateCourseCommand(_dbcontext, _mapper);
            var Course = _dbcontext.Courses.SingleOrDefault(x=> x.Name == newCourse.Name);
           
                command.Model = newCourse;
                CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

       

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id,[FromBody] UpdateCourseModel updateCourse)
        {
            UpdateCourseCommand command = new UpdateCourseCommand(_dbcontext);
            command.CourseId = id;

            command.Model = updateCourse;
            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
                DeleteCourseCommand command = new DeleteCourseCommand(_dbcontext);
                command.CourseId = id;
                DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
        }
    }
}