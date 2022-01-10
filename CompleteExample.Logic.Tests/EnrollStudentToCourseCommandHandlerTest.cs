using CompleteExample.Logic.Commands.EnrollStudentToCourse;
using CompleteExample.Logic.Exceptions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    [TestFixture]
    public class EnrollStudentToCourseCommandHandlerTest : BaseTest
    {
        [Test]
        public void When_Student_NotExists_Should_ThrowException()
        {
            var request = BuildRequest(1, 5);

            var handler = new EnrollStudentToCourseCommandHandler(Context);

            var exception = Assert.ThrowsAsync<UiNotFoundException>(() => handler.Handle(request, CancellationToken.None));
            Assert.AreEqual(exception.ResourceName, "student");
        }

        [Test]
        public void When_Course_NotExists_Should_ThrowException()
        {
            var request = BuildRequest(5, 1);

            var handler = new EnrollStudentToCourseCommandHandler(Context);

            var exception = Assert.ThrowsAsync<UiNotFoundException>(() => handler.Handle(request, CancellationToken.None));
            Assert.AreEqual(exception.ResourceName, "course");
        }

        [Test]
        public void When_EnrollmentAlreadyCreated_Should_ThrowException()
        {
            var request = BuildRequest(1, 1);

            var handler = new EnrollStudentToCourseCommandHandler(Context);

            Assert.ThrowsAsync<UiValidationException>(() => handler.Handle(request, CancellationToken.None));
        }

        [Test]
        public async Task When_ValidationSuccess_Should_CreateEnrollment()
        {
            var request = BuildRequest(2, 1);

            var handler = new EnrollStudentToCourseCommandHandler(Context);

            await handler.Handle(request, CancellationToken.None);

            var createdEnrollment = await Context.Enrollment.FirstOrDefaultAsync(x => x.StudentId == request.StudentId && x.CourseId == x.CourseId);

            Assert.IsNotNull(createdEnrollment);

            Context.Enrollment.Remove(createdEnrollment);
            await Context.SaveChangesAsync();
        }

        private EnrollStudentToCourseCommand BuildRequest(int courseId, int studentId)
        {
            return new EnrollStudentToCourseCommand
            {
                CourseId = courseId,
                StudentId = studentId
            };
        }

    }
}
