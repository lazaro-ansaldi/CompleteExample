using CompleteExample.Logic.Queries.TopStudentsByCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompleteExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        public CoursesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("topStudents")]
        public async Task<TopStudentsByCourseResult> GetTopStudentsByCourseAsync()
        {
            return await MediatorBroker.Send(new TopStudentsByCourseQuery());
        }
    }
}
