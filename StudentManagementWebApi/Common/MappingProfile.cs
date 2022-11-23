using AutoMapper;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.Application.CourseOperations.StudentModels;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.Application.UserOperations.Queries.GetUser;
using StudentManagementWebApi.Application.UserOperations.Queries.GetUserDetail;
using StudentManagementWebApi.Entities;
using TeacherManagementWebApi.Application.CourseOperations.TeacherModels;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;
using static StudentManagementWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
   {
       public MappingProfile()
       {
            CreateMap<CreateCourseModel,Course>();
            CreateMap<Course,CourseDetailViewModel>()
            .ForMember(dest => dest.Student, opt => opt.MapFrom(m => m.StudentCourses.Select(s => s.Student.Name + " " + s.Student.SurName)))
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(m => m.Teacher.Name + " " + m.Teacher.SurName));
            CreateMap<Course,CoursesViewModel>()
            .ForMember(dest => dest.Student, opt => opt.MapFrom(m => m.StudentCourses.Select(s => s.Student.Name + " " + s.Student.SurName)))
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(m => m.Teacher.Name + " " + m.Teacher.SurName));
            CreateMap<CreateStudentModel,Student>();
            CreateMap<Student,StudentDetailViewModel>()
            .ForMember(dest => dest.Course, opt => opt.MapFrom(m => m.StudentCourses.Select(s => s.Course.Name)));
            CreateMap<Student,StudentsViewModel>()
            .ForMember(dest => dest.Course, opt => opt.MapFrom(m => m.StudentCourses.Select(s => s.Course.Name)));
            CreateMap<CreateTeacherModel,Teacher>();
            CreateMap<Teacher,TeacherDetailViewModel>();
            CreateMap<Teacher,TeachersViewModel>();
             CreateMap<CreateUserModel,User>();
            CreateMap<User,UsersViewModel>();
            CreateMap<User,UserDetailViewModel>();
       }
   }
}