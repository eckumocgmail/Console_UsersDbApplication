using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Console_UsersDbApplication.Pages.Roles
{
    public class CreateModel : PageModel
    {
        public readonly UsersDbContext _context;

        public CreateModel(UsersDbContext context)
        {
            _context = context;
            this.AppRoles = _context.Roles.ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AppRole AppRole { get; set; }
        public IEnumerable<AppRole> AppRoles { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Roles.Add(AppRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
