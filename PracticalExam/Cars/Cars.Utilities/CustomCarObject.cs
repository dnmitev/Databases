namespace Cars.Utilities
{
    using System;
    using System.Linq;

    public class CustomCarObject
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public CustomDealer Dealer { get; set; }
    }
}