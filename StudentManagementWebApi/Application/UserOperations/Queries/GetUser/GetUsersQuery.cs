using AutoMapper;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;


namespace StudentManagementWebApi.Application.UserOperations.Queries.GetUser
{
    public class GetUsersQuery
    {
        public readonly IStudentManagementDbContext _dbcontext;
        public readonly IMapper _mapper;

        public GetUsersQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

         public List<UsersViewModel> Handle()
        {
            var userlist = _dbcontext.Users.OrderBy(x => x.Id).ToList<User>();
            List<UsersViewModel> vm = _mapper.Map<List<UsersViewModel>>(userlist);
            return vm;
        }

    }
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password {get; set;}


    }

}