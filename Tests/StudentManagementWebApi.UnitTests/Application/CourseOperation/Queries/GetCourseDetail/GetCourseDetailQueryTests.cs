using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.CourseOperations.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public GetCourseDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenCourseIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetCourseDetailQuery command = new GetCourseDetailQuery(_context,_mapper);
            command.CourseId=0;
                        

            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kurs bulunamadı ...");
        }

        [Fact]
        public void WhenGivenCourseIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetCourseDetailQuery command = new GetCourseDetailQuery(_context,_mapper);
            command.CourseId=1;
            

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var course=_context.Courses.SingleOrDefault(course=>course.Id == command.CourseId);
            course.Should().NotBeNull();
        }
    }
}