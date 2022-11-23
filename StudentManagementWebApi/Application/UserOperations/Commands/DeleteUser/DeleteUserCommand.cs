using StudentManagementWebApi.DBOperations;


namespace StudentManagementWebApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        public int UserId {get; set;}
        
        private readonly IStudentManagementDbContext _dbcontext;

        public DeleteUserCommand(IStudentManagementDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var user = _dbcontext.Users.SingleOrDefault(x=> x.Id == UserId);
            if(user is null)
                throw new InvalidOperationException("Silinecek kullanıcı bulunamadı ...");
            
            _dbcontext.Users.Remove(user);
            _dbcontext.SaveChanges();
        }
    }


}
