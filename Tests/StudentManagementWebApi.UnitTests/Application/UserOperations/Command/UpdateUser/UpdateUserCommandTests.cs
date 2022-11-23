
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateUserCommand command = new UpdateUserCommand(_context);
            command.UserId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kullanıcı bulunamadı...");

        }
        
        [Fact]
        public void WhenGivenUserIdinDB_User_ShouldBeUpdate()
        {
            UpdateUserCommand command = new UpdateUserCommand(_context);

            UpdateUserModel model = new UpdateUserModel(){Name="Gökhan", Surname="Kayhan", Email="gokhankayhan@mail.com", Password="123456"};            
           command.Model = model;
            command.UserId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var user =_context.Users.SingleOrDefault(user=>user.Id == command.UserId);
            user.Should().NotBeNull();
         }
    }
}