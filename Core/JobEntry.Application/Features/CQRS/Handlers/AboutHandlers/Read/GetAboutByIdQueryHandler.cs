using JobEntry.Application.Features.CQRS.Queries.AboutQueries;
using JobEntry.Application.Features.CQRS.Results.AboutResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
{
    private readonly IRepository<About> _aboutRepository;

    public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
    {
         _aboutRepository = aboutRepository;
    }
    
    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _aboutRepository.GetByIdAsync(request.Id);
        return new GetAboutByIdQueryResult()
        {
            Id = value.Id,
            Title = value.Title,
            Description = value.Description,
        };
    }
}