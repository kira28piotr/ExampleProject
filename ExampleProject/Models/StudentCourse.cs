namespace ExampleProject.Models
{
    public class StudentCourse
    {
        //public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public Grade? Grade { get; set; }
    }

    public enum Grade
    {
        ndst = 1,
        dop = 2,
        dst = 3,
        db = 4,
        bdb = 5
    }
}