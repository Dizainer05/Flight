using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int ArrivalAirportId { get; set; }
        public int DepartureAirportId { get; set; }
        public float FlightTime { get; set; }
        public string ServiceClass { get; set; }

        // Навигационные свойства
        public Airport ArrivalAirport { get; set; }
        public Airport DepartureAirport { get; set; }
    }
}
