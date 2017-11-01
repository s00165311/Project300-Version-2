using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Member
    {
        public int Id { get; set; }

        public int ClubID { get; set; }

        public int StudentID { get; set; }

        public virtual ClubsAndSociety ClubsAndSociety { get; set; }

        public virtual Student Student { get; set; }
    }
}
