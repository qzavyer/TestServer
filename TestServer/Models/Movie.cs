using System;
using System.Collections.Generic;
using System.Linq;

namespace TestServer.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int PlaceCount { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public int TicketCount
        {
            get
            {
                if (Tickets == null) return 0;
                return Tickets.Sum(r => r.Count);
            }
        }

        public int EmptyPlaces
        {
            get { return PlaceCount - TicketCount; }
        }
    }
}