using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace TestSetup
{
    public static class Users
    {
        public static void AddUsers(this StudentManagementDbContext context)
        {
            context.Users.AddRange
            (
                new User { Name = "Ahmet", Surname = "Adıvar", Email = "ahmetadivar@mail.com", Password = "123456", RefreshToken="" },
                new User { Name = "Mehmet", Surname = "Elibol", Email = "mehmetelibol@mail.com", Password = "654321", RefreshToken="" }, 
                new User { Name = "Sezin", Surname = "Ekinci", Email = "sezinekinci@mail.com", Password = "123456789", RefreshToken="" }      
            );
        }
    }
}