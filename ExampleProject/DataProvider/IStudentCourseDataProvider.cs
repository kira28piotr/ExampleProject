using System.Collections.Generic;
using ExampleProject.Models;

namespace ExampleProject.DataProvider
{
    public interface IStudentCourseDataProvider
    {
        StudentCourse GetRelationshipById(int? id);
        void SaveStudentCourse(StudentCourse studentCourse);
        void DeleteStudentCourse(int id);
        ICollection<StudentCourse> GetAllStudentCourses();
    }
}