using CompleteExample.Entities.Abstract;
using CompleteExample.Logic.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Queries.TopStudentsByCourse
{
    public class TopStudentsByCourseQueryHandler : BaseQueryHandler<TopStudentsByCourseQuery, TopStudentsByCourseResult>
    {
        public TopStudentsByCourseQueryHandler(IReadOnlySchoolDbContext readOnlySchoolDbContext) : base(readOnlySchoolDbContext)
        {
        }

        protected override async Task<TopStudentsByCourseResult> ExecuteAsync(TopStudentsByCourseQuery request)
        {
            var result = new List<TopStudentsByCourseResult.TopStudentsByCourse>();

            var topEnrollments = await ReadOnlyContext.Enrollment
                .Include(x => x.Course)
                .Include(x => x.Student)
                .GroupBy(x => x.CourseId)
                .Select(x => x.OrderByDescending(x => x.Grade).Take(3))
                .ToListAsync();

            foreach(var enrollment in topEnrollments)
            {
                var course = enrollment.First().Course;
                var courseInfo = new TopStudentsByCourseResult.TopStudentsByCourse.CourseInfo
                {
                    CourseDescription = course.Description,
                    CourseName = course.Title
                };

                var students = enrollment.Select(x => new TopStudentsByCourseResult.TopStudentsByCourse.StudentInfo
                {
                    Email = x.Student.Email,
                    FirstName = x.Student.FirstName,
                    Grade = x.Grade,
                    LastName = x.Student.LastName
                });

                result.Add(new TopStudentsByCourseResult.TopStudentsByCourse(courseInfo, students));
            }

            return new TopStudentsByCourseResult(result);
        }
    }
}
