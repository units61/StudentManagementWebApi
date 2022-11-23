


using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
       

        public DeleteUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenUserIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteUserCommand command = new DeleteUserCommand(_context);
            command.UserId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kullanıcı bulunamadı ...");
        }


        [Fact]
        public void WhenValidInputsAreGiven_User_ShouldBeCreated()
        {
            //arrange
           var user = new User() {Name = "Ahmet", Surname="Adıvar", Email="ahmetadivar@mail.com", Password="123456" };
           _context.Add(user);
           _context.SaveChanges();

           DeleteUserCommand command = new DeleteUserCommand(_context);
           command.UserId = user.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            user = _context.Users.SingleOrDefault(x=> x.Id == user.Id);
            user.Should().BeNull();
        }
    }

}