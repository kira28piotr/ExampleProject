using Autofac;
using ExampleProject.DataProvider;
using ExampleProject.Models;
using ExampleProject.Services;

namespace ExampleProject.Bootstrapper
{
    public class Bootstrapper : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentDataProvider>().As<IStudentDataProvider>().InstancePerRequest();
            builder.RegisterType<CourseDataProvider>().As<ICourseDataProvider>().InstancePerRequest();
            builder.RegisterType<StudentCourseDataProvider>().As<IStudentCourseDataProvider>().InstancePerRequest();

            builder.RegisterType<DataService<Student>>().As<IDataService<Student>>().InstancePerRequest();
            builder.RegisterType<DataService<Course>>().As<IDataService<Course>>().InstancePerRequest();
            builder.RegisterType<DataService<StudentCourse>>().As<IDataService<StudentCourse>>().InstancePerRequest();
            base.Load(builder);
        }
    }
}