using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public float Price { get; set; }
        public int PassengerId { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public string ServiceClass { get; set; }
        public int SeatNumber { get; set; }
        public bool TicketStatus { get; set; }
        public int FlightId { get; set; }

        // Навигационные свойства
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
    }
}
