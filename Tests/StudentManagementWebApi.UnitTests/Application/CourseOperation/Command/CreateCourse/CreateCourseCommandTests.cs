using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Commands.CreateCourse;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TestSetup;
using Xunit;


namespace Tests.StudentManagementWebApi.UnitTests.Application.CourseOperation.Command.CreateCourse
{
    public class CreateCourseCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public CreateCourseCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistCourseIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var course = new Course() {Name="MATEMATİKS", Price=5000, TimeDuration="12 AY",TeacherId=1};
            _context.Courses.Add(course);
            _context.SaveChanges();

            CreateCourseCommand command = new CreateCourseCommand(_context, _mapper);
            command.Model = new CreateCourseModel() {Name = course.Name, Price = course.Price, TimeDuration = course.TimeDuration};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kurs zaten mevcut ...");
        }



        
        [Fact]
        public void WhenValidInputsAreGiven_Course_ShouldBeCreated()
        {
            //arrange
            CreateCourseCommand command = new CreateCourseCommand(_context,_mapper);
            CreateCourseModel model = new CreateCourseModel() {Name="MATEMATİKS", Price=5000, TimeDuration="12 AY"};
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var course = _context.Courses.SingleOrDefault(course => course.Name == model.Name && course.Price == model.Price && course.TimeDuration == model.TimeDuration);
            course.Should().NotBeNull();
        }
        
    }
}