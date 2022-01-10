using System.Collections.Generic;

namespace CompleteExample.Logic.Queries.StudentsByInstructor
{
    public class StudentsByInstructorQueryResult
    {
        public StudentsByInstructorQueryResult(IEnumerable<Student> students) => Students = students;

        public IEnumerable<Student> Students { get; }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public decimal Grade { get; set; }
        }
    }
}
