namespace StudentManagementWebApi.Application.CourseOperations.StudentModels
{
    public class StudentsViewModel
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public IReadOnlyList<string> Course { get; set; }
    }
}