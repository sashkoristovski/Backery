using Bakery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bakery.Pages
{
    public class ContactModel : PageModel

    {
        [BindProperty] public string From { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Subject { get; set; }
        [BindProperty] public string Comments { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var service = new CommentService();
            await service.Send(From, Subject, Email, Comments);
            return RedirectToPage("Thanks");
        }
    }
}
