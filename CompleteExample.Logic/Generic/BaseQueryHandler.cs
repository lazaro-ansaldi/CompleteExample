using CompleteExample.Entities.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Generic
{
    public abstract class BaseQueryHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        public BaseQueryHandler(IReadOnlySchoolDbContext readOnlySchoolDbContext)
        {
            ReadOnlyContext = readOnlySchoolDbContext;
        }

        protected IReadOnlySchoolDbContext ReadOnlyContext { get; }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await ValidateAsync(request);

            return await ExecuteAsync(request);
        }

        protected virtual Task ValidateAsync(TRequest request)
        {
            return Task.FromResult(true);
        }

        protected abstract Task<TResult> ExecuteAsync(TRequest request);
    }
}
