using System;
using PostViewerTool.Properties;

namespace PostViewerTool.Model
{
    /// <summary>
    /// This is the Model for Posts that contains all the data members
    /// </summary>
    public class Post
    {
        // On deserialization needs to create an object of this class, and then set its attributes one-by-one from the source.
        // To make it, the serializer must construct the object, and it uses the default empty parameterless constructor for that. 
        // It cannot use other constructors, because it does not know what attributes it needs to pass to them.
        public Post(){}

        /// <summary>
        /// Construct the Object of Post
        /// </summary>
        /// <param name="userid">userId of Post </param>
        /// <param name="id">Post Id </param>
        /// <param name="title">Title of Post </param>
        /// <param name="body">body of post</param>
        public Post(int userid, int id, string title, string body)
        {
            this.UserId = userid;
            this.Id = id;
            this.Title = title;
            this.Body = body;
        }

        /// <summary>
        /// Represents the Data member userId of Post
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Represents the Data member Id of Post
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the Data member Title of Post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the Data member Body of Post 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Converts the Post into string representation 
        /// </summary>
        public override string ToString()
        {
            return string.Format(Resources.Post_Tostring, this.UserId, this.Id, Environment.NewLine, Title, Environment.NewLine, Body);
        }
    }
}
