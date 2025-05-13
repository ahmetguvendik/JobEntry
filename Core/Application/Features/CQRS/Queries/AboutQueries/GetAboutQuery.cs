using System.Collections.Generic;
using JobEntry.Application.Features.CQRS.Results.AboutResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.AboutQueries;

public class GetAboutQuery : IRequest<List<GetAboutQueryResult>>
{
    
}