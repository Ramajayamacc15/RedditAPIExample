using System;
using System.Collections.Generic;
using System.Text;

namespace MyRedditClientDataAccessLib.Model
{
    public class Post
    {
        public int ID { get; set; }
        public int SubRedditId { get; set; }
        public string SubReddit { get; set; }
        public string Title { get; set; }
        public int Awards { get; set; }
        public string Author { get; set; }
        public int Score { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public override bool Equals(object obj)
        {
            var objA = obj as Post;
            if (objA != null)
                return objA.Author.Equals(this.Author) &&
                        objA.Title.Equals(this.Title) &&
                        objA.PostTime == this.PostTime;
            return false;
        }
    }
}
