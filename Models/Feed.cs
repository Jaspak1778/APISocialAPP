using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISocialAPP.Models
{
    public class Post
    {
        public int? id { get; set; }
        public Author? author { get; set; }
        public string? content { get; set; }
        public DateTime? created { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>(); // Lisää tämä rivi
        public class Author
        {
            public int? id { get; set; }
            public string? username { get; set; }
            public string? first_name { get; set; }
            public string? last_name { get; set; }
        }
    }
    public class Comment
    {
        public int? id { get; set; }
        public Commenter? commenter { get; set; }
        public Post? post { get; set; }
        public string? comment_content { get; set; }
        public DateTime? created { get; set; }

        public class Commenter
        {
            public int? id { get; set; }
            public string? username { get; set; }
            public string? first_name { get; set; }
            public string? last_name { get; set; }
        }
    }
}
