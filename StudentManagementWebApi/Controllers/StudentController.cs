
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWebApi.Application.StudentOperations.Commands.CreateStudent;
using StudentManagementWebApi.Application.StudentOperations.Commands.DeleteStudent;
using StudentManagementWebApi.Application.StudentOperations.Commands.UpdateStudent;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.Application.StudentOperations.Queries.GetDetailStudent;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Application.StudentOperations.Queries.GetStudent;
using StudentManagementWebApi.Application.CourseOperations.StudentModels;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagementWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public StudentController(IStudentManagementDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _dbcontext = context;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetStudent()
        {
           GetStudentQuery query = new GetStudentQuery(_dbcontext, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            StudentDetailViewModel result;
            GetStudentDetailQuery query = new GetStudentDetailQuery(_dbcontext, _mapper);
            query.StudentId= id;
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateStudentModel newStudent)
        {
            CreateStudentCommand command = new CreateStudentCommand(_dbcontext, _mapper);
            var Student = _dbcontext.Students.SingleOrDefault(x=> x.Name == newStudent.Name);
           
                command.Model = newStudent;
                CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

       

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,[FromBody] UpdateStudentModel updateStudent)
        {
            UpdateStudentCommand command = new UpdateStudentCommand(_dbcontext);
            command.StudentId = id;

            command.Model = updateStudent;
            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
                DeleteStudentCommand command = new DeleteStudentCommand(_dbcontext);
                command.StudentId = id;
                DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
        }
    }
}