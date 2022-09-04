using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Console_UsersDbApplication.Pages.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly UsersDbContext _context;

        public DeleteModel(UsersDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppRole AppRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppRole = await _context.Roles.FirstOrDefaultAsync(m => m.AppRoleId == id);

            if (AppRole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppRole = await _context.Roles.FindAsync(id);

            if (AppRole != null)
            {
                _context.Roles.Remove(AppRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
