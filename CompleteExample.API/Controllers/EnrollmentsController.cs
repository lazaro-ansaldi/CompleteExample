using CompleteExample.Logic.Commands.EnrollStudentToCourse;
using CompleteExample.Logic.Commands.UpdateEnrollmentGrade;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompleteExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : BaseController
    {
        public EnrollmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task EnrollStudentToCourseAsync([FromBody] EnrollStudentToCourseCommand arguments)
        {
            await MediatorBroker.Send(arguments);
        }

        [HttpPut]
        public async Task UpdateEnrollmentGradeAsync([FromBody] UpdateEnrollmentGradeCommand arguments)
        {
            await MediatorBroker.Send(arguments);
        }
    }
}
