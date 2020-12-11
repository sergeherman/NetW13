using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MeetingPlanner2020.Models
{
    public class Talk
    {
        [Display(Name = "Talk #")]
        public int ID { get; set; }
        [Display(Name = "Speaker #")]
        public int position { get; set; }
        [Display(Name = "Speaker")]
        public Person Speaker { get; set; }        
        [Display(Name = "Talk Title")]
        public string TalkTitle { get; set; }
        [Display(Name = "Subject")]
        List<Subject> Subjects{ get; set; }
    }
}
