﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeetingPlanner2020.Data;
using MeetingPlanner2020.Models;

namespace MeetingPlanner2020.Pages.Talks
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
            return Page();
        }

        [BindProperty]
        public Talk Talk { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Talk.Add(Talk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
