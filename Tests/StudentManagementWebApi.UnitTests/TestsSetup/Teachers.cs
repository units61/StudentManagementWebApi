using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace TestSetup
{
    public static class Teachers
    {
        public static void AddTeachers(this StudentManagementDbContext context)
        {
            context.Teachers.AddRange
            (
                new Teacher { Name="ANIL", SurName="KOCAYİĞİT", Qulification="MATEMATİK" },
                new Teacher { Name="ÖZGÜR", SurName="KÜÇÜKKURT", Qulification="İNGİLİZCE" },
                new Teacher { Name="YASEMİN", SurName="AKICI", Qulification="TÜRKÇE" },
                new Teacher { Name="HASAN", SurName="ARI", Qulification="TARİH" }
            );
        }
    }
}