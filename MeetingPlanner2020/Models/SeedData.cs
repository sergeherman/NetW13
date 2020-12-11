using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MeetingPlanner2020.Data;
using System;
using System.Linq;

namespace MeetingPlanner2020.Models
{
    public class SeedData
    {
        public DateTime GetDayFromWeek(DateTime week, DayOfWeek day)
        {
            DayOfWeek startDay = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;


            // get the begining of the week 
            int diff = (int)week.DayOfWeek - (int)startDay;
            DateTime beginingOfWeek = week.AddDays(diff * -1);


            // get the day we are looking for
            diff = (int)day - (int)startDay;
            if (diff < 0)
                diff = 7 - (int)startDay;
            return beginingOfWeek.AddDays(diff);
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MeetingPlanner2020Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MeetingPlanner2020Context>>()))
            {
                // Look for any songs.
                if (context.Song.Any())
                {
                    return;   // DB has been seeded
                }
                // Look for any subjects.
                if (context.Subject.Any())
                {
                    return;   // DB has been seeded
                }
                // Look for any members.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }                                

                // Look for any meetings.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new MeetingPlanner2020.Models.Song { SongTitle = "I Stand All Amazed" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "In Humility, Our Savior" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "Jesus, Once of Humble Birth" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "There Is a Green Hill Far Away" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "As Now We Take the Sacrament" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "How Great the Wisdom and the Love" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "God Loved Us, So He Sent His Son" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "God, Our Father, Hear Us Pray" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "Jesus of Nazareth, Savior and King" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "We’ll Sing All Hail to Jesus’ Name " },
                    new MeetingPlanner2020.Models.Song { SongTitle = "O God, the Eternal Father" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "Father in Heaven, We Do Believe" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "With Humble Heart" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "Upon the Cross of Calvary" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "Behold the Great Redeemer Die" },
                    new MeetingPlanner2020.Models.Song { SongTitle = "Because I Have Been Given Much" }                    
                );

                context.Subject.AddRange(
                    new MeetingPlanner2020.Models.Subject { ThemeTitle = "Jesus Christ" },
                    new MeetingPlanner2020.Models.Subject { ThemeTitle = "Faith" },
                    new MeetingPlanner2020.Models.Subject { ThemeTitle = "Repentance" },
                    new MeetingPlanner2020.Models.Subject { ThemeTitle = "Baptism" },
                    new MeetingPlanner2020.Models.Subject { ThemeTitle = "Gift of the Holy Ghost" },
                    new MeetingPlanner2020.Models.Subject { ThemeTitle = "Enduring to the End" }
                );

                context.Person.AddRange(                                                                               
                ) ; 

                context.Meeting.AddRange(
                    new MeetingPlanner2020.Models.Meeting
                    {
                        dateOf = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek),
                        timeOf = DateTime.Today.AddHours(9),
                        ConductingId = 1,
                        Conducting = new MeetingPlanner2020.Models.Person { imageURL = "", Firstname = "Graham", Lastname = "Pearl", Calling = LeadershipCalling.Bishop },
                        PrayerOpeningId = 3,
                        PrayerOpening = new MeetingPlanner2020.Models.Person { imageURL = "", Firstname = "Siarhei", Lastname = "Herman", Calling = LeadershipCalling.PresidentEQ },
                        PrayerClosingId = 2,
                        PrayerClosing = new MeetingPlanner2020.Models.Person { imageURL = "", Firstname = "Amy", Lastname = "Pearl", Calling = LeadershipCalling.PresidentRS }
                    }
                ); 

                context.SaveChanges();
            }
        }
    }
}
