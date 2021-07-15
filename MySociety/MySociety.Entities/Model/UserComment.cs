namespace MySociety.Entities.Model
{
    using System;

    public class UserComment
    {
        public string CommentId { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string CommentText { get; set; }
    }
}
