namespace Bookstore.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Bookstore.Data;
    using Bookstore.Models;
    using System.IO;
    using System.Text;

    public class BookParser : XmlDataParser
    {
        public BookParser(BookstoreData data, string filePath)
            : base(data, filePath)
        {
        }

        public override void ParseFile()
        {
            var streamReader = new StreamReader(this.PathToFile, Encoding.UTF8);
            var itemsCollection = XElement.Load(streamReader).Elements();

            foreach (var item in itemsCollection)
            {
                var title = this.GetSingleValue("title", item);
                var webSite = this.GetSingleValue("web-site", item);
                var price = this.GetSingleValue("price", item);
                var isbn = this.GetIsbn(item);

                var currentBook = new Book()
                {
                    Title = title,
                    ISBN = isbn,
                    WebSite = webSite
                };

                if (price != null)
                {
                    currentBook.Price = decimal.Parse(price);
                }

                var authors = this.GetAuthors(item);
                foreach (var author in authors)
                {
                    currentBook.Authors.Add(author);
                }

                var reviews = this.GetReviews(item);
                foreach (var review in reviews)
                {
                    currentBook.Reviews.Add(review);
                }

                this.Data.Books.Add(currentBook);
                this.Data.SaveChanges();
            }
        }

        private IList<Review> GetReviews(XElement item)
        {
            var reviewsList = new List<Review>();

            var reviews = item.Element("reviews");

            if (reviews != null)
            {
                foreach (var review in reviews.Elements("review"))
                {
                    if (review != null)
                    {
                        var reviewContent = review.Value;
                        var reviewDate = review.Attribute("date");
                        var reviewAuthor = review.Attribute("author");

                        var currentReview = new Review()
                        {
                            Content = reviewContent,
                            CreationDate = reviewDate == null ? DateTime.Now : DateTime.Parse(reviewDate.Value)
                        };

                        if (reviewAuthor != null)
                        {
                            var authorToInsert = this.GetAuthorByName(reviewAuthor.Value);
                            currentReview.Author = authorToInsert;
                        }

                        reviewsList.Add(currentReview);
                    }
                }
            }

            return reviewsList;
        }

        private IList<Author> GetAuthors(XElement item)
        {
            var authorsList = new List<Author>();

            var authors = this.GetMultipleValues("author", item.Element("authors"));

            foreach (var name in authors)
            {
                var authorToInsert = this.GetAuthorByName(name);
                authorsList.Add(authorToInsert);
            }

            return authorsList;
        }

        private Author GetAuthorByName(string name)
        {
            var authorToInsert = this.Data.Authors.All().FirstOrDefault(a => a.Name == name);

            if (authorToInsert == null)
            {
                authorToInsert = new Author()
                {
                    Name = name
                };
            }

            return authorToInsert;
        }

        private string GetIsbn(XElement item)
        {
            var isbn = this.GetSingleValue("isbn", item);

            if (isbn != null)
            {
                if (this.Data.Books.All().Any(b => b.ISBN == isbn))
                {
                    throw new ArgumentException("Duplicated ISBN is not allowed.");
                }
            }

            return isbn;
        }
    }
}