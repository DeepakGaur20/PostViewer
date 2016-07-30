using System;
using System.Net;

namespace ServiceAPI
{
    public class ServiceApi : IServiceApi
    {
        /// <summary>
        /// Represents the URL of API
        /// </summary>
        private readonly string _serviceUrl;

        /// <summary>
        /// Construct the Instance of API
        /// </summary>
        /// <param name="uri"> The Url Api</param>
        public ServiceApi(string uri)
        {
            if(string.IsNullOrEmpty(uri))
            {
                throw new ArgumentException("Invalid URL of API");
            }

            this._serviceUrl = uri;
        }
        
        /// <summary>
        /// Returns the text of API
        /// </summary>
        /// <returns>text of API</returns>
        public string GetAll()
        {
            return Load(this._serviceUrl);
        }

        /// <summary>
        /// Returns the text of a specific element
        /// </summary>
        /// <param name="id">Id that require to fetch the text</param>
        /// <returns>text of a specific element </returns>
        public string GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Invalid Id");
            }

            var content = Load(string.Format(this._serviceUrl + "/" + id));
            return content;
        }

        /// <summary>
        /// Loads the text from API
        /// </summary>
        /// <returns>text from API</returns>
        private string Load(string url)
        {
            using (WebClient apiClient = new WebClient())
            {
                var downloadString = apiClient.DownloadString(url);
                return downloadString;
            }
        }
    }

   
}
