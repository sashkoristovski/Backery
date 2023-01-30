using Bakery.Data;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace Bakery.Pages
{
    public class OrderModel : PageModel
    {
        private readonly BakeryContext _context;
        public OrderModel(BakeryContext context)
        {
            _context= context;

        }

        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        [BindProperty, EmailAddress, Required, Display(Name = "Your Email Address")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a shipping address"), Display(Name = "Shipping Address")]
        public string OrderShipping { get; set; }
        [BindProperty, Display(Name = "Quantity")]
        public int OrderQuantity { get; set; } = 1;


        public Product Productss { get; set; }


        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Productss = await _context.Products.FindAsync(Id);
            }


            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Productss = await _context.Products.FindAsync(Id);

            if (ModelState.IsValid)
            { 
                var body = $@"<p>Thank you, we have received your order for {OrderQuantity} unit(s) of {Productss.Name}!</p>
                 <p>Your address is: <br/>{OrderShipping.Replace("\n", "<br/>")}</p>
                     Your total is ${Productss.Price * OrderQuantity}.<br/>
                     We will contact you if we have questions about your order.  Thanks!<br/>";
             
                using (var smtp = new SmtpClient())
            {

                    var credential = new NetworkCredential
                    {
                        UserName = "sashkoristovski2018",  // replace with valid value
                        Password = "Maria2003Sashman"  // replace with valid value
                    };
                    
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;


                    var message = new MailMessage();
                    message.To.Add(OrderEmail);
                    message.Subject = "Fourth Coffee - New Order";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("sashkoristovski2018@gmail.com");
                    await smtp.SendMailAsync(message);
            }

            return RedirectToPage("OrderSuccess");
            }
            return Page();
        }

    }
}
