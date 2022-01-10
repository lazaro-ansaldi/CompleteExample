using MediatR;

namespace CompleteExample.Logic.Commands.EnrollStudentToCourse
{
    public sealed class EnrollStudentToCourseCommand : IRequest<Unit>
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}
