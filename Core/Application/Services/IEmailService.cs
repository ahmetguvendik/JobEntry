namespace JobEntry.Application.Services;

public interface IEmailService
{
    public Task SendApplyAppEmailAsync(string emailAdress, string body);
    public Task SendSeenAppEmailAsync(string emailAdress, string body);
}