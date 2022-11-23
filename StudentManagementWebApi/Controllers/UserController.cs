
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWebApi.Application.UserOperations.Commands.CreateToken;
using StudentManagementWebApi.Application.UserOperations.Commands.CreateUser;
using StudentManagementWebApi.Application.UserOperations.Commands.DeleteUser;
using StudentManagementWebApi.Application.UserOperations.Commands.RefreshToken;
using StudentManagementWebApi.Application.UserOperations.Commands.UpdateUser;
using StudentManagementWebApi.Application.UserOperations.Queries.GetUser;
using StudentManagementWebApi.Application.UserOperations.Queries.GetUserDetail;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.TokenOperations.Models;
using static StudentManagementWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;


namespace StudentManagementWebApi.Controllers
{
   
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public UserController(IStudentManagementDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _dbcontext = context;
            _configuration = configuration;
            _mapper = mapper;
        }

       

        [HttpGet("refreshToken")]
        
            public ActionResult<Token> RefreshToken([FromQuery] string token)
            {
                RefreshTokenCommand command = new RefreshTokenCommand(_dbcontext,_configuration);
                command.RefreshToken = token;
                var resultToken = command.Handle();
                return resultToken;
            }
        
        [HttpGet]
        public IActionResult GetUser()
        {
           GetUsersQuery query = new GetUsersQuery(_dbcontext, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserDetailViewModel result;
            GetUserDetailQuery query = new GetUserDetailQuery(_dbcontext, _mapper);
            query.UserId = id;
            GetUserDetailQeuryValidator validator = new GetUserDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_dbcontext, _mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_dbcontext, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,[FromBody] UpdateUserModel updateuser)
        {
            UpdateUserCommand command = new UpdateUserCommand(_dbcontext);
            command.UserId = id;

            command.Model = updateuser;
            UpdateUserCommandValidator validator = new UpdateUserCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
                DeleteUserCommand command = new DeleteUserCommand(_dbcontext);
                command.UserId = id;
                DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }
    }
}