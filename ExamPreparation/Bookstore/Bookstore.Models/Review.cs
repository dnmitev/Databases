namespace Bookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Content { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}