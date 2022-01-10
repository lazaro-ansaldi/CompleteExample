using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Entities.Abstract
{
    public interface ISchoolDbContext : IDisposable
    {
        DbSet<Course> Courses { get; }
        DbSet<Student> Students { get; }
        DbSet<Enrollment> Enrollment { get; }
        DbSet<Instructor> Instructors { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
