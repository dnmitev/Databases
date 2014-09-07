namespace Bookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Author
    {
        private ICollection<Book> books;
        private ICollection<Review> reviews;

        public Author()
        {
            this.Books = new HashSet<Book>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;
            }
        }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }
    }
}