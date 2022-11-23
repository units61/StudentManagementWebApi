using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementWebApi.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName {get; set;}
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public bool IsActive {get; set;} = true;
        public virtual ICollection<StudentCourse> StudentCourses {get; set;}
    }
}