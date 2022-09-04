using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Console_UsersDbApplication.Pages.Shared
{
    public class UsersModel : PageModel
    {
        private readonly UsersDbContext _context;

        public UsersModel(UsersDbContext context)
        {
            _context = context;
        }

        public IList<AppUser> AppUser { get;set; }

        public async Task OnGetAsync()
        {
            AppUser = await _context.Users.ToListAsync();
        }
    }
}
