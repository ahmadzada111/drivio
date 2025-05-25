namespace Drivio.Shared.Settings;

public record EmailSettings(
    string From, 
    string SmtpServer, 
    int Port,
    string UserName,
    string Password);