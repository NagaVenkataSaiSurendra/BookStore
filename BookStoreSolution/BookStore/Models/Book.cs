﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }   
        public DateOnly PublishedDate { get; set; }
        public int Price {  get; set; }
        public int ISBN { get; set; }

    }
}
