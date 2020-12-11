using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeetingPlanner2020.Models;

namespace MeetingPlanner2020.Data
{
    public class MeetingPlanner2020Context : DbContext
    {
        public MeetingPlanner2020Context (DbContextOptions<MeetingPlanner2020Context> options)
            : base(options)
        {
        }

        public DbSet<MeetingPlanner2020.Models.Song> Song { get; set; }

        public DbSet<MeetingPlanner2020.Models.Subject> Subject { get; set; }

        public DbSet<MeetingPlanner2020.Models.Person> Person { get; set; }

        public DbSet<MeetingPlanner2020.Models.Talk> Talk { get; set; }

        public DbSet<MeetingPlanner2020.Models.Meeting> Meeting { get; set; }
    }
}
