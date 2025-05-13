using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CategoryCommands;

public class UpdateCategoryCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string IconURL { get; set; }
}