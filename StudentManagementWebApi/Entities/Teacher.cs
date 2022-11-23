using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementWebApi.Entities
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName {get; set;}
        public string Qulification { get; set; }
        public bool IsActive {get; set;} = true;
    }
}