using AutoMapper;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.TokenOperations;
using StudentManagementWebApi.TokenOperations.Models;

namespace StudentManagementWebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken {get; set;}
        private readonly IStudentManagementDbContext _dbcontext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IStudentManagementDbContext dbContext, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

                _dbcontext.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Valid bir Refresh Token Bulunamadı!");
        }
    }
}