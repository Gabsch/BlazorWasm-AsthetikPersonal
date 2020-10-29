using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabsch.AsthetikPersonal.Models
{
    public class BookingItem
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Time{ get; set; }
        public decimal Price { get; set; }
    }
}
