using CompleteExample.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompleteExample.Entities
{
    public class SchoolDbContext : DbContext, IReadOnlySchoolDbContext, ISchoolDbContext
    {

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .ToTable("Students", schema: "dbo");

            modelBuilder.Entity<Course>()
                .ToTable("Courses", schema: "dbo");

            modelBuilder.Entity<Enrollment>()
                .ToTable("Enrollment", schema: "dbo");

            modelBuilder.Entity<Instructor>()
                .ToTable("Instructors", schema: "dbo");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        IQueryable<Course> IReadOnlySchoolDbContext.Courses => Courses.AsNoTracking();
        IQueryable<Student> IReadOnlySchoolDbContext.Students => Students.AsNoTracking();
        IQueryable<Enrollment> IReadOnlySchoolDbContext.Enrollment => Enrollment.AsNoTracking();
        IQueryable<Instructor> IReadOnlySchoolDbContext.Instructors => Instructors.AsNoTracking();
    }
}
