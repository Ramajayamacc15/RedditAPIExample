using System;
using System.Collections.Generic;
using System.Linq;
using MyRedditClientDataAccessLib;
using MyRedditClientDataAccessLib.Model;
using Reddit;

namespace MyRedditClient
{
    class ClientProgram
    {
        static MyRedditDataAccessor dataAccess;
        static void Main(string[] args)
        {
            string appId = "xxxxxxxxxxxxxxxx";
            string refreshToken = "xxxxxxxxxxxxxx-xxxxxxxxxxxx";
            string accessToken = "682682646623-xxxxxxxxxx-xxxxxxxxxxxxxxx";

            RedditClient reddit = new RedditClient(appId: appId, refreshToken: refreshToken, accessToken: accessToken);
            dataAccess = new MyRedditDataAccessor();
            List<Post> newPosts = new List<Post>();
            List<Comment> newComments = new List<Comment>();
            foreach (var s in dataAccess.GetAllSubReddits())
            {
                var sub = reddit.Subreddit(s.Name).About();
                sub.Posts.NewUpdated += C_NewPostsUpdated;
                sub.Posts.MonitorNew(30 * 1000);  // Toggle on.

                foreach (var newPost in sub.Posts.GetNew())
                {
                    if(!(s.Posts.Where(p => p.Equals(newPost)).Count() > 0))
                    {
                        newPosts.Add(Utility.GetPostModel(newPost));
                    }

                    foreach (var newComment in newPost.Comments.GetNew())
                    {
                        if (!(dataAccess.GetAllComments().Where(c => c.Equals(newComment)).Count() > 0))
                            newComments.Add(Utility.GetCommentModel(newComment));
                        newPost.Comments.MonitorNew(30 & 1000);  // Toggle on.
                        newPost.Comments.NewUpdated += C_NewCommentsUpdated;
                    } 
                }
            }
            dataAccess.AddNewPost(newPosts);
            dataAccess.AddComment(newComments);
        }
        static void C_NewPostsUpdated(object sender, Reddit.Controllers.EventArgs.PostsUpdateEventArgs e)
        {
            foreach (var post in e.Added)
            {
                Console.WriteLine("[" + post.Subreddit + "] New Post by " + post.Author + ": " + post.Title);
                dataAccess.AddNewPost(Utility.GetPostModel(post));
            }
        }
        static void C_NewCommentsUpdated(object sender, Reddit.Controllers.EventArgs.CommentsUpdateEventArgs e)
        {
            foreach (var comment in e.Added)
            {
                Console.WriteLine("[" + comment.Subreddit + "/" + comment.Root.Title + "] New Comment by " + comment.Author + ": " + comment.Body);
                dataAccess.AddComment(Utility.GetCommentModel(comment));
            }
        }
    }
}
