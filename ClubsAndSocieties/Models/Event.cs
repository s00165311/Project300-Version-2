using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Event
    {
        public int Id { get; set; }

        
        public string Title { get; set; }

        public string Description { get; set; }

       
        public string Location { get; set; }


        public byte[] Image { get; set; }

       
        public virtual ICollection<ClubEvent> ClubEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
