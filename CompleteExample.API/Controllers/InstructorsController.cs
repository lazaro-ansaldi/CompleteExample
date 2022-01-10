using CompleteExample.Logic.Queries.StudentsByInstructor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompleteExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : BaseController
    {
        public InstructorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet()]
        [Route("{instructorId}/grades")]
        public async Task<StudentsByInstructorQueryResult> GetStudentsByInstructorAsync(int instructorId)
        {
            var queryArgs = new StudentsByInstructorQuery(instructorId);
            return await MediatorBroker.Send(queryArgs);
        }
    }
}
