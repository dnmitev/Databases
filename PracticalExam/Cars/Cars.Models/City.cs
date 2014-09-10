namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        private ICollection<Dealer> dealers;

        public City()
        {
            this.Dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Dealer> Dealers
        {
            get
            {
                return this.dealers;
            }

            set
            {
                this.dealers = value;
            }
        }
    }
}