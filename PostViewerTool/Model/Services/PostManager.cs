using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using PostViewerTool.Properties;
using ServiceAPI;

namespace PostViewerTool.Model.Services
{
    /// <summary>
    /// Represents postmanager class that manages the post.
    /// </summary>
    public class PostManager
    {
        /// <summary>
        /// Constant of posts
        /// </summary>
        const string Jsonlistconst = "{\"Posts\":";

        /// <summary>
        /// Represents the API
        /// </summary>
        private readonly IServiceApi _serviceApi;

        // On deserialization needs to create an object of this class, and then set its attributes one-by-one from the source.
        // To make it, the serializer must construct the object, and it uses the default parameterless constructor for that. 
        // It cannot use other constructors, because it does not know what attributes it needs to pass to them.
        public PostManager() { }

        /// <summary>
        /// Construct the object 
        /// </summary>
        public PostManager(string uri)
        {
            _serviceApi = new ServiceApi(uri);
            Task.Run(() => this.GetPosts());
        }

        /// <summary>
        /// Gets and the Posts of API 
        /// Here, Set is used for deserialization with that Post Manager service prepared the list of posts.  
        /// </summary>
        public List<Post> Posts { get; set; }

        /// <summary>
        /// Gets the Posts from API 
        /// </summary>
        private void GetPosts()
        {
            string content = _serviceApi.GetAll();
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException(Resources.ExceptionMessage_InvalidJSON_Data);
            }

            string text = Jsonlistconst + content + "}";
            var postListData = (PostManager)new JavaScriptSerializer().Deserialize(text, typeof(PostManager));
            if (postListData != null)
            {
                this.Posts = postListData.Posts;
            }
        }
        
        /// <summary>
        /// Loads the the text of a selected post
        /// </summary>
        /// <param name="postid">Post Id</param>
        /// <returns>text of a specific post </returns>
        public string GetSinglePost(string postid)
        {
            string content = _serviceApi.GetById(postid);
            return content;
        }
    }
}
