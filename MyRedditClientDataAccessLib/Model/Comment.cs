using System;
using System.Collections.Generic;
using System.Text;

namespace MyRedditClientDataAccessLib.Model
{
    public class Comment
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CommentTime { get; set; }
        public int Depth { get; set; }
        public int Awards { get; set; }
        public int Score { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }

        public override bool Equals(object obj)
        {
            var objA = obj as Comment;
            if(objA != null)
            {
                return objA.Body.Equals(this.Body) &&
                        objA.Author.Equals(this.Author) &&
                        objA.Depth == this.Depth &&
                        objA.CommentTime == this.CommentTime;
            }
            return false;
        }
    }
}
