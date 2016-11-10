﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TestServer.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public int TicketCount
        {
            get
            {
                return Tickets?.Sum(r => r.Count) ?? 0;
            }
        }
    }
}