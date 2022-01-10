using CompleteExample.Logic.Commands.UpdateEnrollmentGrade;
using CompleteExample.Logic.Exceptions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    [TestFixture]
    public class UpdateEnrollmentGradeCommandHandlerTest : BaseTest
    {
        private const int EXISTING_ENROLLMENT_ID = 1;

        [Test]
        public void When_EnrollmentNotExists_Should_ThrowException()
        {
            var request = BuildRequest(100, 5);

            var handler = new UpdateEnrollmentGradeCommandHandler(Context);

            var exception = Assert.ThrowsAsync<UiNotFoundException>(() => handler.Handle(request, CancellationToken.None));
            Assert.AreEqual(exception.ResourceName, "enrollment");
        }

        [Test]
        public void When_GradeIsMinusThanZero_Should_ThrowException()
        {
            var request = BuildRequest(1, -1);

            var handler = new UpdateEnrollmentGradeCommandHandler(Context);

            var exception = Assert.ThrowsAsync<UiValidationException>(() => handler.Handle(request, CancellationToken.None));
            Assert.AreEqual(exception.ErrorMessage, "Grade must be greater than zero.");
        }

        [Test]
        public async Task When_ValidationsSuccess_Should_UpdateGrade()
        {
            var expectedGrade = (decimal)7.87;
            var request = BuildRequest(EXISTING_ENROLLMENT_ID, expectedGrade);

            var handler = new UpdateEnrollmentGradeCommandHandler(Context);
            await handler.Handle(request, CancellationToken.None);

            var enrollment = await Context.Enrollment.FirstOrDefaultAsync(x => x.EnrollmentId == EXISTING_ENROLLMENT_ID);

            Assert.AreEqual(enrollment.Grade, expectedGrade);
        }

        private UpdateEnrollmentGradeCommand BuildRequest(int enrollmentId, decimal grade)
        {
            return new UpdateEnrollmentGradeCommand
            {
                EnrollmentId = enrollmentId,
                Grade = grade
            };
        }
    }
}
