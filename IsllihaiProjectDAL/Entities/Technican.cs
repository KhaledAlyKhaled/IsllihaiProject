using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Entities
{
    public class Technican
    {
        public int Id { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsVertified { get; set; }
        public double AvgRating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
