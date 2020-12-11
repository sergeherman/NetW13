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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MeetingPlanner2020.Pages.Persons
{
    public class EditModel : PageModel
    {
        private readonly MeetingPlanner2020.Data.MeetingPlanner2020Context _context;
        private readonly String WebRootPath;

        public EditModel(MeetingPlanner2020.Data.MeetingPlanner2020Context context)
        {
            _context = context;            
            WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder =
                    Path.Combine(WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString()+"_" + Path.GetFileName(Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

            }
            return uniqueFileName;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
                
            if (Photo != null)
                {
                // deletes the old outdated photo when no longer used
                    if (Person.imageURL != null)
                    {
                        string filePath = Path.Combine(WebRootPath, "images", Person.imageURL);
                        System.IO.File.Delete(filePath);
                    }

                    Person.imageURL = ""+ ProcessUploadedFile();
                }           

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.ID))
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

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.ID == id);
        }
    }
}
