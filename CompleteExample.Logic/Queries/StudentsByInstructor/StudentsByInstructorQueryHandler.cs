using CompleteExample.Entities.Abstract;
using CompleteExample.Logic.Exceptions;
using CompleteExample.Logic.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Queries.StudentsByInstructor
{
    public sealed class StudentsByInstructorQueryHandler : BaseQueryHandler<StudentsByInstructorQuery, StudentsByInstructorQueryResult>
    {
        public StudentsByInstructorQueryHandler(IReadOnlySchoolDbContext readOnlySchoolDbContext) : base(readOnlySchoolDbContext)
        {
        }

        protected override async Task<StudentsByInstructorQueryResult> ExecuteAsync(StudentsByInstructorQuery request)
        {
            var queryResult = await ReadOnlyContext.Enrollment
                .Include(x => x.Student)
                .Include(x => x.Course)
                .Where(enrollment => enrollment.Course.InstructorId == request.InstructorId)
                .ToListAsync();

            var studentsDto = queryResult.Select(result => new StudentsByInstructorQueryResult.Student
            {
                FirstName = result.Student.FirstName,
                LastName = result.Student.LastName,
                Email = result.Student.Email,
                Grade = result.Grade
            });

            return new StudentsByInstructorQueryResult(studentsDto);
        }

        protected override async Task ValidateAsync(StudentsByInstructorQuery request)
        {
            var isInstructorValid = await ReadOnlyContext.Instructors.AnyAsync(x => x.InstructorId == request.InstructorId);

            if (!isInstructorValid)
            {
                throw new UiNotFoundException("instructor");
            }
        }
    }
}
