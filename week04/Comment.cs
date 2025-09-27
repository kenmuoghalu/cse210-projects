using System;

namespace YouTubeVideoProgram
{
    public class Comment
    {
        // Private member variables
        private string _commenterName;
        private string _commentText;

        // Constructor
        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        // Method to get formatted comment information
        public string GetCommentInfo()
        {
            return $"{_commenterName}: {_commentText}";
        }

        // Getter methods for the commenter name and text (optional, but good practice)
        public string GetCommenterName()
        {
            return _commenterName;
        }

        public string GetCommentText()
        {
            return _commentText;
        }
    }
}