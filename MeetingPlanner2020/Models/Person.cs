using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MeetingPlanner2020.Models
{
    public enum LeadershipCalling
    {
        [Display(Name = "Stake President")]
        PresidentStake,
        [Display(Name = "Stake Councilor")]
        StakeC,        
        [Display(Name = "Bishop")]
        Bishop,
        [Display(Name = "Bishop 1st Councilor")]
        Bishop1C,
        [Display(Name = "Bishop 2nd Councilor")]
        Bishop2C,        
        [Display(Name = "Elders Quorum President")]
        PresidentEQ,
        [Display(Name = "Elder")]
        Elder,
        [Display(Name = "Relief Society President")]
        PresidentRS,
        [Display(Name = "Priest")]
        Priest,
        [Display(Name = "Mission President")]
        PresidentMission,
        [Display(Name = "Missionary")]
        Missionary,
        [Display(Name = "None")]
        None
    };
    public class Person
    {
        [Display(Name = "Member #")]        
        public int ID { get; set; }
        [Display(Name = "Image URL")]
        public string imageURL { get; set; }        
        [Display(Name = "First Name")]
        [Required]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string Lastname { get; set; }
        [Display(Name = "Full Name")]
        public string Fullname {
            get { 
            return this.Lastname+", "+ this.Firstname.Substring(0,1)+"."; } 
        }
        [Display(Name = "Calling")]
        public LeadershipCalling Calling { get; set; }
    }
}
