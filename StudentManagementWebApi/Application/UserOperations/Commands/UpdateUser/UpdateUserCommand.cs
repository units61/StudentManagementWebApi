
using StudentManagementWebApi.DBOperations;

namespace StudentManagementWebApi.Application.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        private readonly IStudentManagementDbContext _dbcontext;
        
        public int UserId{get; set;}

        public UpdateUserModel Model{get; set;}
        
        public UpdateUserCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

      public void Handle()
        {
            var user = _dbcontext.Users.SingleOrDefault(x=> x.Id == UserId);
            if(user is null)
                throw new InvalidOperationException("Güncellenecek kullanıcı bulunamadı...");
            
            user.Name = Model.Name != default ? Model.Name : user.Name;
            user.Surname = Model.Surname != default ? Model.Surname : user.Surname;
            user.Email = Model.Email != default ? Model.Email : user.Email;
            user.Password = Model.Password != default ? Model.Password : user.Password;
            

            _dbcontext.SaveChanges();
        }
    }
     public class UpdateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
}