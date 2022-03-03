using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLines.Models
{
    public class InputModel
    {
        public int Type { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
