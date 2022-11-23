using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using TeacherManagementWebApi.Application.TeacherOperations.Queries.GetDetailTeacher;
using TestSetup;
using Xunit;

namespace TeacherManagementWebApi.Application.TeacherOperations.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public GetTeacherDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenTeacherIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetTeacherDetailQuery command = new GetTeacherDetailQuery(_context,_mapper);
            command.TeacherId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Öğretmen bulunamadı ...");
        }

        [Fact]
        public void WhenGivenTeacherIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetTeacherDetailQuery command = new GetTeacherDetailQuery(_context,_mapper);
            command.TeacherId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var teacher=_context.Teachers.SingleOrDefault(teacher=>teacher.Id == command.TeacherId);
            teacher.Should().NotBeNull();
        }
    }
}