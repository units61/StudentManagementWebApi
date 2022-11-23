
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.CreateTeacher;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;
using TeacherManagementWebApi.Application.TeacherOperations.Queries.GetDetailTeacher;
using TeacherManagementWebApi.Application.TeacherOperations.Queries.GetTeacher;
using TeacherManagementWebApi.Application.CourseOperations.TeacherModels;
using StudentManagementWebApi.DBOperations;
using Microsoft.AspNetCore.Authorization;

namespace TeacherManagementWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class TeacherController : ControllerBase
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public TeacherController(IStudentManagementDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _dbcontext = context;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetTeacher()
        {
           GetTeacherQuery query = new GetTeacherQuery(_dbcontext, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TeacherDetailViewModel result;
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(_dbcontext, _mapper);
            query.TeacherId= id;
            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] CreateTeacherModel newTeacher)
        {
            CreateTeacherCommand command = new CreateTeacherCommand(_dbcontext, _mapper);
            var Teacher = _dbcontext.Teachers.SingleOrDefault(x=> x.Name == newTeacher.Name);
           
                command.Model = newTeacher;
                CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

       

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id,[FromBody] UpdateTeacherModel updateTeacher)
        {
            UpdateTeacherCommand command = new UpdateTeacherCommand(_dbcontext);
            command.TeacherId = id;

            command.Model = updateTeacher;
            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
                DeleteTeacherCommand command = new DeleteTeacherCommand(_dbcontext);
                command.TeacherId = id;
                DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
        }
    }
}