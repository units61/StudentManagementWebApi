using AutoMapper;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;


namespace StudentManagementWebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateUserCommand(IStudentManagementDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbcontext.Users.SingleOrDefault(x=> x.Email == Model.Email);
            if(user is not null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");
            
            user = _mapper.Map<User>(Model);
            
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string RefreshToken { get; set; }
            public DateTime RefreshTokenExpireDate { get; set; }
        }
    }
}