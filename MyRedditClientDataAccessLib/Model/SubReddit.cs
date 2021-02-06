using System;
using System.Collections.Generic;
using System.Text;

namespace MyRedditClientDataAccessLib.Model
{
    public class SubReddit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
