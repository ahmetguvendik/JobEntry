namespace JobEntry.DTO.CommentDTOs;

public class ResultCommentDto
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime CreatedTime { get; set; }
}