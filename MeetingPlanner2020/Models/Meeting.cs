using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPlanner2020.Models
{
    public class Meeting
    {
        [Display(Name = "Meeting #")]
        public int ID { get; set; }
        [Display(Name = "Date")]        
        [DataType(DataType.Date)]
        [Required]
        public DateTime dateOf { get; set; }
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [Required]
        public DateTime timeOf { get; set; }
        [Display(Name = "Conducting")]
        [Required]
        public int? ConductingId { get; set; }
        [ForeignKey("ConductingId")]
        [Display(Name = "Conducting")]
        public Person Conducting { get; set; }
        [Display(Name = "Opening Prayer")]
        public int? PrayerOpeningId { get; set; }
        [ForeignKey("PrayerOpeningId")]
        [Display(Name = "Opening Prayer")]
        public Person PrayerOpening { get; set; }
        [Display(Name = "Closing Prayer")]
        public int? PrayerClosingId { get; set; }
        [ForeignKey("PrayerClosingId")]
        [Display(Name = "Closing Prayer")]
        public Person PrayerClosing { get; set; }
        [Display(Name = "Songs")]
        public ICollection<Song> Songs { get; set; }
        [Display(Name = "Talks")]
        public ICollection<Talk> Talks { get; set; }
    }
}
