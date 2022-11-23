namespace StudentManagementWebApi.Application.CourseOperations.CourseModels
{
    public class CoursesViewModel
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public int Price { get; set; }
        public string TimeDuration { get; set; }
        public string Teacher {get; set;}
        public IReadOnlyList<string> Student { get; set; }
    }
}