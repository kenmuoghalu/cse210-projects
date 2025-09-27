using System;
using System.Collections.Generic;

namespace YouTubeVideoProgram
{
    public class Video
    {
        // Private member variables
        private string _title;
        private string _author;
        private int _length; // in seconds
        private List<Comment> _comments;

        // Constructor
        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length = length;
            _comments = new List<Comment>();
        }

        // Method to add a comment
        public void AddComment(string commenterName, string commentText)
        {
            Comment newComment = new Comment(commenterName, commentText);
            _comments.Add(newComment);
        }

        // Method to get the number of comments
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        // Method to display video details and comments
        public void DisplayVideoDetails()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_length} seconds");
            Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in _comments)
            {
                Console.WriteLine($"  - {comment.GetCommentInfo()}");
            }
            Console.WriteLine(); // Add a blank line for separation
        }

        // Getter methods (optional, but good practice)
        public string GetTitle()
        {
            return _title;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public int GetLength()
        {
            return _length;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }
}