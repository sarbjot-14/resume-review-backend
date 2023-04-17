using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Resumes
{
    public class List
    {
        public class Query : IRequest<List<Resume>> {}

        public class Handler : IRequestHandler<Query, List<Resume>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Resume>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Resumes.ToListAsync();
            }
        }
    }
}