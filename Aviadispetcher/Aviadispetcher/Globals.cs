using System;
using System.Collections.Generic;

namespace Aviadispetcher
{
    public class Flight
    {
        public Flight() { }
        public Flight(string nF, string cF, string tf, string fS)
        {
            Number = nF;
            City = cF;
            DepatureTime = tf;
            FreeSeats = fS;
        }
        public string Number { get; set; }
        public string City { get; set; }
        public string DepatureTime { get; set; }
        public string FreeSeats { get; set; }
    }
}