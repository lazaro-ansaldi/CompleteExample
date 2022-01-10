using CompleteExample.Logic.Queries.TopStudentsByCourse;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    [TestFixture]
    public class TopStudentsByCourseQueryHandlerTests : BaseTest
    {
        public TopStudentsByCourseQueryHandlerTests()
        {
        }

        [Test]
        public async Task When_ValidationsSucces_Should_ReturnStudents()
        {
            var request = new TopStudentsByCourseQuery();
            var handler = new TopStudentsByCourseQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotEmpty(result.TopStudents);
            Assert.AreEqual(result.TopStudents.First().Course.CourseName, "Test Course");
        }
    }
}
