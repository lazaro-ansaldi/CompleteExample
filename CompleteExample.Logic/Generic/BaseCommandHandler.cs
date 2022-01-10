using CompleteExample.Entities.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Generic
{
    public abstract class BaseCommandHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        public BaseCommandHandler(ISchoolDbContext schoolDbContext)
        {
            SchoolDbContext = schoolDbContext;
        }

        protected ISchoolDbContext SchoolDbContext { get; }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await ValidateAsync(request);

            var result = await ExecuteAsync(request);

            await SchoolDbContext.SaveChangesAsync();

            return result;
        }

        protected virtual Task ValidateAsync(TRequest request)
        {
            return Task.FromResult(true);
        }

        protected abstract Task<TResult> ExecuteAsync(TRequest request);
    }
}
