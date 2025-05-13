using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CategoryCommands;

public class CreateCategoryCommand : IRequest
{
    public string Name { get; set; }
    public string IconURL { get; set; }
}   