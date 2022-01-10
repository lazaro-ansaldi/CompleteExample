using CompleteExample.Entities;
using CompleteExample.Entities.Abstract;
using CompleteExample.Logic.Exceptions;
using CompleteExample.Logic.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Commands.UpdateEnrollmentGrade
{
    public sealed class UpdateEnrollmentGradeCommandHandler : BaseCommandHandler<UpdateEnrollmentGradeCommand, Unit>
    {
        private Enrollment ExistingEnrollment { get; set; }

        public UpdateEnrollmentGradeCommandHandler(ISchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }

        protected override Task<Unit> ExecuteAsync(UpdateEnrollmentGradeCommand request)
        {
            ExistingEnrollment.Grade = request.Grade;

            return Unit.Task;
        }

        protected override async Task ValidateAsync(UpdateEnrollmentGradeCommand request)
        {
            if (request.Grade < decimal.Zero)
            {
                throw new UiValidationException("Grade must be greater than zero.");
            }

            ExistingEnrollment = await SchoolDbContext.Enrollment.FirstOrDefaultAsync(x => x.EnrollmentId == request.EnrollmentId);

            if (ExistingEnrollment is null)
            {
                throw new UiNotFoundException("enrollment");
            }
        }
    }
}
