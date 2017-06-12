using System;
using System.Collections.Generic;
using ExampleProject.Models;
using ExampleProject.Services;

namespace ExampleProject.DataProvider
{
    public class StudentDataProvider : IStudentDataProvider
    {
        private readonly Func<IDataService<Student>> _dataServiceCreator;

        public StudentDataProvider(Func<IDataService<Student>> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }
        //Nie usuniesz, bo IDisposable nakłada taką restrykcje.
        public Student GetStudentById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetById(id.Value);
            }
        }

        public void SaveStudent(Student student)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Save(student);
            }
        }

        public void DeleteStudent(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Delete(id);
            }
        }

        public ICollection<Student> GetAllStudents()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAll();
            }
        }
    }
}