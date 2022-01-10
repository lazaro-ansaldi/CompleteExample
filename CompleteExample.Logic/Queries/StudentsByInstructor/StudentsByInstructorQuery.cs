using MediatR;

namespace CompleteExample.Logic.Queries.StudentsByInstructor
{
    public sealed class StudentsByInstructorQuery : IRequest<StudentsByInstructorQueryResult>
    {
        public StudentsByInstructorQuery(int instructorId) => InstructorId = instructorId;

        public int InstructorId { get; }
    }
}
