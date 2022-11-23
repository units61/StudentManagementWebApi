using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementWebApi.Entities
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price {get; set;}
        public string TimeDuration { get; set; }
        public bool IsActive {get; set;} = true;
        public int TeacherId {get; set;}
        public Teacher Teacher {get; set;}
        public virtual ICollection<StudentCourse> StudentCourses {get; set;}
    }
}