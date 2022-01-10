using CompleteExample.Entities;
using CompleteExample.Entities.Abstract;
using CompleteExample.Logic.Exceptions;
using CompleteExample.Logic.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Commands.EnrollStudentToCourse
{
    public sealed class EnrollStudentToCourseCommandHandler : BaseCommandHandler<EnrollStudentToCourseCommand, Unit>
    {
        public EnrollStudentToCourseCommandHandler(ISchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }

        protected override Task<Unit> ExecuteAsync(EnrollStudentToCourseCommand request)
        {
            var enrollment = new Enrollment
            {
                CourseId = request.CourseId,
                StudentId = request.StudentId
            };

            SchoolDbContext.Enrollment.Add(enrollment);

            return Unit.Task;
        }

        protected override async Task ValidateAsync(EnrollStudentToCourseCommand request)
        {
            var isStudentIdValid = await SchoolDbContext.Students.AnyAsync(student => student.StudentId == request.StudentId);

            if (!isStudentIdValid)
            {
                throw new UiNotFoundException("student");
            }

            var isCourseIdValid = await SchoolDbContext.Courses.AnyAsync(course => course.CourseId == request.CourseId);

            if (!isCourseIdValid)
            {
                throw new UiNotFoundException("course");
            }

            var existingEnrollment = await SchoolDbContext.Enrollment
                .Where(x => x.StudentId == request.StudentId && x.CourseId == request.CourseId)
                .FirstOrDefaultAsync();

            if (existingEnrollment != null)
            {
                throw new UiValidationException($"Enrollment for course {request.CourseId} and student {request.StudentId} already exists.");
            }
        }
    }
}
