using IsllihaiProjectDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int price { get; set; }
        public string Address { get; set; }
        public DateTime OrderedAt { get; set; }
        public string Description { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int? TechnicanId { get; set; }
        public Technican? Technican { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Review Review { get; set; }

    }
}
