using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingPlanner2020.Models
{
    
    public class Subject
    {
        [Display(Name = "Subject #")]
        public int ID { get; set; }
        [Display(Name = "Theme Title")]
        public string ThemeTitle { get; set; }
    }
}
