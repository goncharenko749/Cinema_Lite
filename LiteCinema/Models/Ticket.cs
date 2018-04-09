using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCinema.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Buyer { get; set; }
        public int BuyerPhone { get; set; }
        public string BuyerEmail { get; set; }


        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
