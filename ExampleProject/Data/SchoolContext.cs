using System.Data.Entity;
using ExampleProject.Models;

namespace ExampleProject.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SchoolContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasKey(n => n.Id);
            modelBuilder.Entity<Student>().HasKey(n => n.Id);
            modelBuilder.Entity<StudentCourse>().HasKey(n => new {n.CourseId, n.StudentId});
            modelBuilder.Entity<StudentCourse>()
                .HasRequired(q => q.Course)
                .WithMany(q => q.StudentCourses)
                .HasForeignKey(q => q.CourseId);
            modelBuilder.Entity<StudentCourse>()
                .HasRequired(q => q.Student)
                .WithMany(q => q.StudentCourses)
                .HasForeignKey(q => q.StudentId);

        }

        public static SchoolContext Create ()
        {
            return new SchoolContext();
        }
    }
}