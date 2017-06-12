using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ExampleProject.Data;
using ExampleProject.Models;

namespace ExampleProject.Services
{
    public class DataService<T> : IDataService<T> where T : class
    {
        private readonly SchoolContext _schoolContext;

        private bool _isDisposed;

        public DataService()
        {
            _schoolContext = new SchoolContext();
        }

        public T GetById(int id)
        {
            return _schoolContext.Set<T>().Find(id);
        }

        public void Save(T obj)
        {
            _schoolContext.Set<T>().AddOrUpdate(obj);
            _schoolContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var remove = _schoolContext.Set<T>().Find(id);
            if (remove != null)
                _schoolContext.Set<T>().Remove(remove);
            _schoolContext.SaveChanges();
        }


        public ICollection<T> GetAll()
        {
             return _schoolContext.Set<T>().Select(n => n).ToList();
        }

        //Musi być bo interfejs dziedziczy po IDisposable
        public void Dispose()
        {
            //Na razie nie implementuje bo nie jest to tematem lekcji i jak samego GC.
        }


    }
}