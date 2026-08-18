using IsllihaiProjectDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int Phone { get; set; }
        public string email { get; set; }
        public Roles Role {  get; set; }
        public Technican Technican { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
