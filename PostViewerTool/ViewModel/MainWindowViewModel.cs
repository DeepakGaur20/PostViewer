using System.Globalization;
using System.Windows;
using PostViewerTool.Properties;
using PostViewerTool.ViewModel.Base;
using System.ComponentModel;
using System;
using PostViewerTool.Model.Services;
using PostViewerTool.ViewModel.Enum;

namespace PostViewerTool.ViewModel
{
    partial class MainWindowViewModel: ViewModelBase
    {
        /// <summary>
        /// Represents the object of service class PostManager
        /// </summary>
        readonly PostManager _postManager;

        /// <summary>
        /// Represents the text format that was copied
        /// </summary>
        private TextFormat _textFormat = TextFormat.None;

        /// <summary>
        /// Represents the object of BackgroundWorker Thread
        /// </summary>
        private readonly BackgroundWorker _worker;
        
        /// <summary>
        /// Construct the View Model Object
        /// </summary>
        public MainWindowViewModel()
        {
            _postManager = new PostManager(Resources.Application_JsonwebApiurlstring);
            using (this._worker = new BackgroundWorker())
            {
                this._worker.WorkerSupportsCancellation = true;
                this._worker.DoWork += this.DoWork;
                this._worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            }          
        }

        #region Private Methods

        /// <summary>
        /// Clears the Data Bindings
        /// </summary>
        private void Clear()
        {
            Posts = null;
            CopyContent = null;
            _textFormat = TextFormat.None;
            IsVisible = false;
        }

        /// <summary>
        /// Execute the Fetch command to load the posts
        /// </summary>
        private void Fetch()
        {            
            if(_postManager.Posts!=null && _postManager.Posts.Count>0)
            {
                Posts = _postManager.Posts;
            }
            else
            {
                throw new ArgumentException(Resources.ExceptionMessage_AccessdeniedInvalidURLstring);
            }
        }

        /// <summary>
        /// Can Execute Fetch
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanExecuteFetch()
        {
            if (Posts != null && Posts.Count > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Can Execute Clear
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanExecuteClear()
        {
            if (Posts != null && Posts.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Copies the Post
        /// </summary>
        private void Copy(TextFormat textformat)
        {
            _textFormat = textformat;
            if (textformat == TextFormat.Text)
            {
                CopyContent = SelectedPost.ToString();
            }
            else
            {
                // Gets the Post from post manager service with search criteria Id.
                string singlepost = _postManager.GetSinglePost(SelectedPost.Id.ToString(CultureInfo.InvariantCulture));
                if (textformat == TextFormat.Json)
                {
                    CopyContent = singlepost;
                }
                if (textformat == TextFormat.Html)
                {
                    CopyContent = Utility.Conversion.ToHtml(singlepost);
                }
                if (textformat == TextFormat.Xml)
                {
                    CopyContent = Utility.Conversion.ToXml(singlepost);
                }
            }
        }

        /// <summary>
       /// Executes the Copy method in Async
       /// </summary>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            IsVisible = true;
            this.Copy((TextFormat)e.Argument);
        }

        /// <summary>
        /// Background Worker completion
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if(!string.IsNullOrEmpty(CopyContent))
                {
                    // Copy the content on Clip Board
                    Clipboard.SetDataObject(CopyContent, true);
                }
              
                IsVisible = false;
                if (e.Error != null)
                    throw e.Error;
            }
        }

        #endregion
 
    }
}
