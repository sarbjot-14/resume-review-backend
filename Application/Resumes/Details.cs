
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Resumes
{
    public class Details
    {
        public class Query : IRequest<Result<Resume>>{
            public Guid Id {get;set;}
        }

        public class Handler : IRequestHandler<Query, Result<Resume>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Result<Resume>> Handle(Query request, CancellationToken cancellationToken)
            {
                var resume = await _context.Resumes.FindAsync(request.Id);
            

                return Result<Resume>.Success(resume);
            }

            // Task<Result<Resume>> IRequestHandler<Query, Result<Resume>>.Handle(Query request, CancellationToken cancellationToken)
            // {
            //     throw new NotImplementedException();
            // }
        }
    }
}