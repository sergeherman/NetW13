using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeetingPlanner2020.Data;
using MeetingPlanner2020.Models;

namespace MeetingPlanner2020.Pages.Meetings
{
    public class CreateModel : PageModel
    {
        private readonly MeetingPlanner2020.Data.MeetingPlanner2020Context _context;

        public CreateModel(MeetingPlanner2020.Data.MeetingPlanner2020Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ConductingId"] = new SelectList(_context.Person, "ID", "Fullname");
        ViewData["PrayerClosingId"] = new SelectList(_context.Person, "ID", "Fullname");
        ViewData["PrayerOpeningId"] = new SelectList(_context.Person, "ID", "Fullname");
            return Page();
        }

        [BindProperty]
        public Meeting Meeting { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meeting.Add(Meeting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
