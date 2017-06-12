using System.Collections.Generic;
using ExampleProject.Models;

namespace ExampleProject.DataProvider
{
    public interface IStudentDataProvider
    {
        Student GetStudentById(int? id);
        void SaveStudent(Student student);
        void DeleteStudent(int id);
        ICollection<Student> GetAllStudents();
    }
}