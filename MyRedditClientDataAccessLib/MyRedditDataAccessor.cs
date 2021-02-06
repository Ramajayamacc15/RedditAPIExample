using MyRedditClientDataAccessLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyRedditClientDataAccessLib
{
    public class MyRedditDataAccessor
    {
        private MyRedditClientDbContext _dbContext;
        public MyRedditDataAccessor()
        {
            _dbContext = new MyRedditClientDbContext();
        }

        public List<SubReddit> GetAllSubReddits()
        {
            return _dbContext.SubReddits.ToList();
        }

        public List<Post> GetAllPosts()
        {
            return _dbContext.Posts.ToList();
        }
        public List<Post> GetAllPosts(string subReddit)
        {
            return _dbContext.Posts.Where(p => p.SubReddit == subReddit).ToList();
        }

        public List<Comment> GetAllComments()
        {
            return _dbContext.Comments.ToList();
        }
        public bool AddNewPost(Post post)
        {
            try
            {
                _dbContext.Posts.Add(post);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                //Log
                return false;
            }
        }
        public bool AddNewPost(IEnumerable<Post> post)
        {
            try
            {
                if (post.Count() <= 0)
                    return false;
                _dbContext.Posts.AddRange(post);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //Log
                return false;
            }
        }

        public bool AddComment(Comment comment)
        {
            try
            {
                _dbContext.Comments.Add(comment);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                //log 
                return false;
            }
        }
        public bool AddComment(IEnumerable<Comment> comment)
        {
            try
            {
                if (comment.Count() <= 0)
                    return false;
                _dbContext.Comments.AddRange(comment);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //log 
                return false;
            }
        }
    }
}
