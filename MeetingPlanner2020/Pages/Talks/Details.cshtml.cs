using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetingPlanner2020.Data;
using MeetingPlanner2020.Models;

namespace MeetingPlanner2020.Pages.Talks
{
    public class DetailsModel : PageModel
    {
        private readonly MeetingPlanner2020.Data.MeetingPlanner2020Context _context;

        public DetailsModel(MeetingPlanner2020.Data.MeetingPlanner2020Context context)
        {
            _context = context;
        }

        public Talk Talk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Talk = await _context.Talk.FirstOrDefaultAsync(m => m.ID == id);

            if (Talk == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
