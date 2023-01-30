using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentService _commentService;

        public CommentService(ICommentService commentService)
        {
            _commentService = commentService;   
        }
        [BindProperty]
        public string From { get; set; }
        [BindProperty] 
        public string Email { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty] 
        public string Comments { get; set; }


        public async Task<IActionResult> OnPost()
        {
            await _commentService.Send(From, Subject, Email, Comments);
            return RedirectToPage("Thanks");
        }


        public async Task Send(string from, string subject, string email, string comments)
        {
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "sashkoristovski2018@gmail.com",  // replace with valid value
                    Password = "Maria2003Sashman"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                var message = new MailMessage
                {
                    Body = $"From: {from} at {email}<p>{comments}</p>",
                    Subject = subject,
                    IsBodyHtml = true
                };
                message.To.Add("contact@domain.com");
                await smtp.SendMailAsync(message);
            }
        }
    }
}
