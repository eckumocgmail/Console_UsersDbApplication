using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Console_UsersDbApplication.Pages.Shared
{
    public class DetailsModel : PageModel
    {
        private readonly UsersDbContext _context;

        public DetailsModel(UsersDbContext context)
        {
            _context = context;
        }

        public AppUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.Users.FirstOrDefaultAsync(m => m.AppUserID == id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
