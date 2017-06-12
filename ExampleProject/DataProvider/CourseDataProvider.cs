using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExampleProject.Models;
using ExampleProject.Services;

namespace ExampleProject.DataProvider
{
    public class CourseDataProvider : ICourseDataProvider
    {
        private readonly Func<IDataService<Course>> _dataServiceCreator;

        public CourseDataProvider(Func<IDataService<Course>> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public Course GetCourseById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetById(id.Value);
            }
        }

        public void SaveCourse(Course course)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Save(course);
            }
        }

        public void DeleteCourse(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Delete(id);
            }
        }

        public ICollection<Course> GetAllCourses()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAll();
            }
        }
    }
}