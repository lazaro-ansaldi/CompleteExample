using CompleteExample.Logic.Exceptions;
using CompleteExample.Logic.Queries.StudentsByInstructor;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    [TestFixture]
    public class StudentsByInstructorQueryHandlerTests : BaseTest
    {
        public StudentsByInstructorQueryHandlerTests()
        {
        }

        [Test]
        public async Task When_ValidationsSucces_Should_ReturnStudents()
        {
            var request = new StudentsByInstructorQuery(1);

            var handler = new StudentsByInstructorQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotEmpty(result.Students);
            Assert.AreEqual(result.Students.Count(), 1);
        }

        [Test]
        public void When_InstructorNotExists_Should_ThrowException()
        {
            var request = new StudentsByInstructorQuery(100);

            var handler = new StudentsByInstructorQueryHandler(Context);

            var exception = Assert.ThrowsAsync<UiNotFoundException>(() => handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.ResourceName, "instructor");
        }
    }
}
