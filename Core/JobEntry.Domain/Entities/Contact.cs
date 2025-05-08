namespace JobEntry.Domain.Entities;

public class Contact : BaseEntity
{
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreatedTime { get; set; }
    
}