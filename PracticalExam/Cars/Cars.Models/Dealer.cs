﻿namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        private ICollection<City> cities;
        private ICollection<Car> cars;

        public Dealer()
        {
            this.Cities = new HashSet<City>();
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                this.cities = value;
            }
        }
    }
}