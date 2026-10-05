using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string name { get; set; }
        public Technican Technican { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
