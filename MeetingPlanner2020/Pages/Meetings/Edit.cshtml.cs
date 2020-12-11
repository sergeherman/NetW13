using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingPlanner2020.Data;
using MeetingPlanner2020.Models;

namespace MeetingPlanner2020.Pages.Meetings
{
    public class EditModel : PageModel
    {
        private readonly MeetingPlanner2020.Data.MeetingPlanner2020Context _context;

        public EditModel(MeetingPlanner2020.Data.MeetingPlanner2020Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meeting
                .Include(m => m.Conducting)
                .Include(m => m.PrayerClosing)
                .Include(m => m.PrayerOpening).FirstOrDefaultAsync(m => m.ID == id);

            if (Meeting == null)
            {
                return NotFound();
            }
            //see: https://stackoverflow.com/questions/14049098/mvc4-razor-drop-down-list-binding-with-foreign-key
            ViewData["ConductingId"] = new SelectList(_context.Person, "ID", "Fullname", Meeting.ConductingId);
            ViewData["PrayerClosingId"] = new SelectList(_context.Person, "ID", "Fullname", Meeting.PrayerOpeningId);
            ViewData["PrayerOpeningId"] = new SelectList(_context.Person, "ID", "Fullname", Meeting.PrayerClosingId);            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(Meeting.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
