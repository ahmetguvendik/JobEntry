using JobEntry.Application.Features.CQRS.Queries.AppUserQueries;
using JobEntry.Application.Features.CQRS.Results.AppUserResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.AppUserCommands;

public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, GetAppUserQueryResult>
{   
    private readonly IRepository<AppUser>  _repository;

    public GetAppUserQueryHandler(IRepository<AppUser> repository)
    {
         _repository = repository;
    }

    public async Task<GetAppUserQueryResult> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        return new GetAppUserQueryResult()
        {
            Id = user.Id,
            Email = user.Email,
            NameSurname = user.UserName
        };
    }
}