using System;
using System.Linq;

namespace CompleteExample.Entities.Abstract
{
    public interface IReadOnlySchoolDbContext : IDisposable
    {
        IQueryable<Course> Courses { get; }
        IQueryable<Student> Students { get; }
        IQueryable<Enrollment> Enrollment { get; }
        IQueryable<Instructor> Instructors { get; }
    }
}
