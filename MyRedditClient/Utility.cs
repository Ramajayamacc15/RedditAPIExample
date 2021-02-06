using MyRedditClientDataAccessLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRedditClient
{
    public static class Utility
    {
        public static Post GetPostModel(Reddit.Controllers.Post post)
        {
            return new Post
            {
                Author = post.Author,
                Title = post.Title,
                UpVotes = post.UpVotes,
                DownVotes = post.DownVotes,
                Score = post.Score,
                Awards = post.Awards.Count
            };
        }

        public static Comment GetCommentModel(Reddit.Controllers.Comment comment)
        {
            return new Comment
            {
                Body = comment.Body,
                Depth = comment.Depth,
                UpVotes = comment.UpVotes,
                DownVotes = comment.DownVotes,
                Author = comment.Author,
                Awards = comment.Awards.Count,
                Score = comment.Score
            };
        }
    }
}
