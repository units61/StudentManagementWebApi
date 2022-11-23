using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.UserOperations.Queries.GetUserDetail
{
    public class GetUserDetailQuery
    {
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int UserId {get; set;}

        public GetUserDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public UserDetailViewModel Handle()
        {
            var user = _dbcontext.Users.Where(user=> user.Id == UserId).SingleOrDefault(); 
            if(user is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı...");  
            UserDetailViewModel vm = _mapper.Map<UserDetailViewModel>(user);
            return vm;      
        }
    }
     public class UserDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
}

