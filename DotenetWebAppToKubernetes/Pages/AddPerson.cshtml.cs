using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotnetWebAppToKubernetes.Data;
using DotnetWebAppToKubernetes.Models;

namespace DotnetWebAppToKubernetes.Pages
{
    public class AddPersonModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddPersonModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }

        public string? Message { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.People.Add(Person);
            _context.SaveChanges();

            Message = "Person added successfully!";
            ModelState.Clear();

            return Page();
        }
    }
}
