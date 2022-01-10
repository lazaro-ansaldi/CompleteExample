using MediatR;

namespace CompleteExample.Logic.Commands.UpdateEnrollmentGrade
{
    public sealed class UpdateEnrollmentGradeCommand : IRequest<Unit>
    {
        public int EnrollmentId { get; set; }
        public decimal Grade { get; set; }
    }
}
