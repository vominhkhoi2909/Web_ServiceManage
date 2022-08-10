namespace MockProject.API.Reponsitory.Interface
{
    public interface IMailRepository
    {
        Task SendMail(string toEmail, string subject, string content);
    }
}
