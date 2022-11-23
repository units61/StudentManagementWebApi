using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace TestSetup
{
    public static class Courses
    {
        public static void AddCourses(this StudentManagementDbContext context)
        {
              context.Courses.AddRange(
                    new Course { Name="MATEMATİK", Price=5000, TimeDuration="12 AY",TeacherId=1},
                    new Course { Name="TÜRKÇE", Price=3000, TimeDuration="6 AY",TeacherId=3},
                    new Course { Name="İNGİLİZCE", Price=3500, TimeDuration="3 AY",TeacherId=2},
                    new Course { Name="TARİH", Price=2000, TimeDuration="4 AY",TeacherId=4}
                );
        }
    }
}