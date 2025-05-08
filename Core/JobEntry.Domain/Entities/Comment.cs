namespace JobEntry.Domain.Entities;

public class Comment : BaseEntity
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime CreatedTime { get; set; }
}