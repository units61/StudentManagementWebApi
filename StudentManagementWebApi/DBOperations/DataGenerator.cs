
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApi.Entities;

namespace StudentManagementWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentManagementDbContext(serviceProvider.GetRequiredService<DbContextOptions<StudentManagementDbContext>>()))
            {

                context.Courses.AddRange(
                    new Course { Name="MATEMATİK", Price=5000, TimeDuration="12 AY",TeacherId=1},
                    new Course { Name="TÜRKÇE", Price=3000, TimeDuration="6 AY",TeacherId=3},
                    new Course { Name="İNGİLİZCE", Price=3500, TimeDuration="3 AY",TeacherId=2},
                    new Course { Name="TARİH", Price=2000, TimeDuration="4 AY",TeacherId=4}
                );

                context.Students.AddRange
                (
                    new Student { Name="MUHAMMET BAĞBUR", SurName="AYGÜN", PhoneNumber="5321234567", Adress="BEŞİKTAŞ", Email="muhammetaygun@mail.com"},
                    new Student { Name="ERTAN", SurName="AYDOĞMUŞ", PhoneNumber="5327651877", Adress="ORTAKÖY", Email="ertanaydogmus@mail.com"},
                    new Student { Name="MUHSİN", SurName="ATİK", PhoneNumber="5328771937", Adress="NİŞANTAŞI", Email="muhsinatik@mail.com"}
                );

                
                context.Teachers.AddRange
                (
                    new Teacher { Name="ANIL", SurName="KOCAYİĞİT", Qulification="MATEMATİK" },
                    new Teacher { Name="ÖZGÜR", SurName="KÜÇÜKKURT", Qulification="İNGİLİZCE" },
                    new Teacher { Name="YASEMİN", SurName="AKICI", Qulification="TÜRKÇE" },
                    new Teacher { Name="HASAN", SurName="ARI", Qulification="TARİH" }
                );

                context.StudentCourses.AddRange(
                    new StudentCourse{ StudentId = 1, CourseId = 1},
                    new StudentCourse{ StudentId = 1, CourseId = 3},
                    new StudentCourse{ StudentId = 2, CourseId = 1},
                    new StudentCourse{ StudentId = 2, CourseId = 2},
                    new StudentCourse{ StudentId = 2, CourseId = 3},
                    new StudentCourse{ StudentId = 2, CourseId = 4},
                    new StudentCourse{ StudentId = 3, CourseId = 2},
                    new StudentCourse{ StudentId = 3, CourseId = 4}       
                    );

                context.Users.AddRange(
                    new User { Name = "Ahmet", Surname = "Adıvar", Email = "ahmetadivar@mail.com", Password = "123456", RefreshToken="" },
                    new User { Name = "Mehmet", Surname = "Elibol", Email = "mehmetelibol@mail.com", Password = "654321", RefreshToken="" }, 
                    new User { Name = "Sezin", Surname = "Ekinci", Email = "sezinekinci@mail.com", Password = "123456789", RefreshToken="" }      
                    );

                context.SaveChanges();
            }
        }
    }
}