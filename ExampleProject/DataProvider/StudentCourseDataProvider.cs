using System;
using System.Collections.Generic;
using ExampleProject.Models;
using ExampleProject.Services;

namespace ExampleProject.DataProvider
{
    public class StudentCourseDataProvider : IStudentCourseDataProvider
    {
        private readonly Func<IDataService<StudentCourse>> _dataServiceCreator;

        public StudentCourseDataProvider(Func<IDataService<StudentCourse>> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public StudentCourse GetRelationshipById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetById(id.Value);
            }
        }

        public void SaveStudentCourse(StudentCourse studentCourse)
        {
           using (var dataService = _dataServiceCreator())
            {
                dataService.Save(studentCourse);
            }
        }

        public void DeleteStudentCourse(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Delete(id);
            }
        }

        public ICollection<StudentCourse> GetAllStudentCourses()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAll();
            }
        }
    }
}