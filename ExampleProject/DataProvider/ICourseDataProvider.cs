using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using ExampleProject.Models;

namespace ExampleProject.DataProvider
{
    public interface ICourseDataProvider
    {
        Course GetCourseById(int? id);
        void SaveCourse(Course course);
        void DeleteCourse(int id);
        ICollection<Course> GetAllCourses();
    }
}