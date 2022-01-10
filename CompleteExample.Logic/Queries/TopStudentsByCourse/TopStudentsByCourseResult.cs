using System.Collections.Generic;

namespace CompleteExample.Logic.Queries.TopStudentsByCourse
{
    public sealed class TopStudentsByCourseResult
    {
        public TopStudentsByCourseResult(IEnumerable<TopStudentsByCourse> topStudents) => TopStudents = topStudents;

        public IEnumerable<TopStudentsByCourse> TopStudents { get; }

        public class TopStudentsByCourse
        {
            public TopStudentsByCourse(CourseInfo courseInfo, IEnumerable<StudentInfo> studentInfos)
            {
                Course = courseInfo;
                Students = studentInfos;
            }

            public CourseInfo Course { get; set; }
            public IEnumerable<StudentInfo> Students { get; set; }

            public class CourseInfo
            {
                public string CourseName { get; set; }
                public string CourseDescription { get; set; }
            }

            public class StudentInfo
            {
                public decimal Grade { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
            }
        }
    }
}
