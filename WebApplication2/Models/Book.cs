using System;

namespace WebApplication2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }

        public string MLACitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.Now.Year}.";
        public string ChicagoCitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {DateTime.Now.Year}.";
    }

    

}
