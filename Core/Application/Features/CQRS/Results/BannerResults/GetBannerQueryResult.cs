namespace JobEntry.Application.Features.CQRS.Results.BannerResults;

public class GetBannerQueryResult
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}