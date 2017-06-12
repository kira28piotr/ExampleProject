using System;
using System.Collections.Generic;
using ExampleProject.Models;

namespace ExampleProject.Services
{
    public interface IDataService<T> : IDisposable
    {
        T GetById(int id);
        void Save(T obj);
        void Delete(int id);
        ICollection<T> GetAll();
    }
}