using CompleteExample.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace CompleteExample.Logic.Tests
{
    public abstract class BaseTest
    {
        protected SchoolDbContext Context { get; set; }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var optionBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            optionBuilder.UseInMemoryDatabase(databaseName: "TestsDb");

            Context = new SchoolDbContext(optionBuilder.Options);
            Context.Database.EnsureDeleted();
            
            SeedDb();
            Context.SaveChanges();
        }

        private void SeedDb()
        {
            Context.Students.Add(new Student
            {
                StudentId = 1,
                Email = "test@gmail.com",
                FirstName = "John",
                LastName = "John Doe",
                TimeZone = "UTC"
            });

            Context.Instructors.Add(new Instructor
            {
                InstructorId = 1,
                Email = "instructor@gmail.com",
                FirstName = "Will",
                LastName = "Smith",
                StartDate = DateTime.Now.AddYears(-2)
            });

            Context.Courses.Add(new Course
            {
                CourseId = 1,
                Credits = 1000,
                Description = "This a test course",
                InstructorId = 1,
                Title = "Test Course",
            });

            Context.Courses.Add(new Course
            {
                CourseId = 2,
                Credits = 2000,
                Description = "Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.",
                InstructorId = 1,
                Title = "Spanish 401",
            });

            Context.Enrollment.Add(new Enrollment
            {
                CourseId = 1,
                EnrollmentId = 1,
                StudentId = 1,
                Grade = 0
            });
        }
    }
}