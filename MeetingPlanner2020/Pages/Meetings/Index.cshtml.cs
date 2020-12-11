using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetingPlanner2020.Data;
using MeetingPlanner2020.Models;

namespace MeetingPlanner2020.Pages.Meetings
{
    public class IndexModel : PageModel
    {
        private readonly MeetingPlanner2020.Data.MeetingPlanner2020Context _context;

        public IndexModel(MeetingPlanner2020.Data.MeetingPlanner2020Context context)
        {
            _context = context;
        }

        public IList<Meeting> Meeting { get;set; }

        public async Task OnGetAsync()
        {
            Meeting = await _context.Meeting
                .Include(m => m.Conducting)
                .Include(m => m.PrayerClosing)
                .Include(m => m.PrayerOpening).ToListAsync();
        }
    }
}
