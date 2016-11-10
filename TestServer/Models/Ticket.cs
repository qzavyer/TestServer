using System;

namespace TestServer.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}