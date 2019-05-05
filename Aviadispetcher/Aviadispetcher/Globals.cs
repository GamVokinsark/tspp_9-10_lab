namespace Aviadispetcher
{
    public class Flight
    {
        public Flight() { }
        public Flight(string nF, string cF, string tf, string fS)
        {
            Number = nF;
            City = cF;
            Depature_time = tf;
            Free_seats = fS;
        }
        public string Number { get; set; }
        public string City { get; set; }
        public string Depature_time { get; set; }
        public string Free_seats { get; set; }
    }
}