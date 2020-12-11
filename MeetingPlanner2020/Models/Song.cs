using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MeetingPlanner2020.Models
{
    public class Song
    {
        [Display(Name = "Song #")]
        public int ID { get; set; }
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }
    }
}
