using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.AboutQueries;
using JobEntry.Application.Features.CQRS.Results.AboutResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
{
    private readonly IRepository<About>  _aboutRepository;

    public GetAboutQueryHandler(IRepository<About> aboutRepository)
    {
         _aboutRepository = aboutRepository;
    }
    
    public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
    {
        var value = await _aboutRepository.GetAllAsync();
        return value.Select(x => new GetAboutQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
        }).ToList();
    }
}