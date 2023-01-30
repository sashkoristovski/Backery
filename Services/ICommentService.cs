namespace Bakery.Services
{
    public interface ICommentService
    {
        Task Send(string from, string subject, string email, string comments);
    }
}
