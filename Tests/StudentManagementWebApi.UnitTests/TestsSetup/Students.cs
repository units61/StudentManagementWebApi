using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;

namespace TestSetup
{
    public static class Students
    {
        public static void AddStudents(this StudentManagementDbContext context)
        {
            context.Students.AddRange
            (
                new Student { Name="MUHAMMET BAĞBUR", SurName="AYGÜN", PhoneNumber="5321234567", Adress="BEŞİKTAŞ", Email="muhammetaygun@mail.com"},
                new Student { Name="ERTAN", SurName="AYDOĞMUŞ", PhoneNumber="5327651877", Adress="ORTAKÖY", Email="ertanaydogmus@mail.com"},
                new Student { Name="MUHSİN", SurName="ATİK", PhoneNumber="5328771937", Adress="NİŞANTAŞI", Email="muhsinatik@mail.com"}
            );
        }
    }
}