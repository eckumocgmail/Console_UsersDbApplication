using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Console_UsersDbApplication.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly UsersDbContext _context;

        public IndexModel(UsersDbContext context)
        {
            _context = context;

        }

        public IList<AppRole> AppRole { get;set; } = new List<AppRole>();   

        public async Task OnGetAsync()
        {
            AppRole = await _context.Roles.ToListAsync();
        }
    }
}
