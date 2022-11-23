using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.Queries.GetDetailStudent;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenStudentIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetStudentDetailQuery command = new GetStudentDetailQuery(_context,_mapper);
            command.StudentId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Öğrenci bulunamadı ...");
        }

        [Fact]
        public void WhenGivenStudentIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetStudentDetailQuery command = new GetStudentDetailQuery(_context,_mapper);
            command.StudentId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var student=_context.Students.SingleOrDefault(student=>student.Id == command.StudentId);
            student.Should().NotBeNull();
        }
    }
}