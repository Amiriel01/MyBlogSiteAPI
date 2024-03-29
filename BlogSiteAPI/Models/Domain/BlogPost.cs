﻿namespace BlogSite.API.Models.Domain
{
    public class BlogPost
    {
        //create properties for BlogPost
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public string BlogImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public bool IsVisible { get; set; }

        //one blog post can have multiple categories 
        //this represents the relation between the categories and the blog post
        public ICollection<Category> Categories { get; set; }
    }
}
