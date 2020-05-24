using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai11_Blog.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<string> Content { get; set; }
        public string File { get; set; }
    }
}