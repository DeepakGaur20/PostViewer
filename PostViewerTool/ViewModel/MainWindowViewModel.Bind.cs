using System.Collections.Generic;
using System.Windows.Input;
using PostViewerTool.Model;
using System.Windows;
using PostViewerTool.ViewModel.Base;
using PostViewerTool.ViewModel.Enum;

namespace PostViewerTool.ViewModel
{
    /// <summary>
    /// This partial class has the definition of Binding that has Properties & Commands of ViewModel.
    /// </summary>
    partial class MainWindowViewModel
    {
        #region Properties 
       /// <summary>
       /// Gets and Set the posts
       /// </summary>
        private List<Post> _posts;
        public List<Post> Posts
        {
            get { return _posts; }
            set 
            {
                _posts = value;
                RaisePropertyChanged("Posts"); 
            }
        }

        /// <summary>
        /// Gets and Set the text of post that copied.
        /// </summary>
         private string _copyContent;
        public string CopyContent
        {
            get { return _copyContent; }
            set 
            {
                _copyContent = value;
                RaisePropertyChanged("CopyContent"); 
            }
        }

        /// <summary>
        /// Gets and Set the selected POST
        /// </summary>
        private Post _selectedPost;
        public Post SelectedPost
        {
            get { return _selectedPost; }
            set 
            {
                _selectedPost = value;
                CopyContent = null;
                _textFormat = TextFormat.None;
                RaisePropertyChanged("SelectedPost"); 
            }
        }

        /// <summary>
        /// Gets and Set the Visibility
        /// </summary>
        private bool _isVisible;
        public bool IsVisible
        {
            get { return this._isVisible; }
            set
            {
                if (this._isVisible != value)
                {
                    this._isVisible = value;
                    this.RaisePropertyChanged("IsVisible");
                }
            }
        }
 
        #endregion

        #region Commands
        /// <summary>
        /// Gets the command object of Copy of JSON text
        /// </summary>
        private ICommand _copyJsoNcommand;
        public ICommand CopyJsonCommand
        {
            get
            {
                return _copyJsoNcommand ?? (_copyJsoNcommand = new Command(p => _worker.RunWorkerAsync(TextFormat.Json), q => SelectedPost != null && _textFormat != TextFormat.Json && !this._worker.IsBusy));
            }
        }

        /// <summary>
        /// Gets the command object of Copy of Plain Text 
        /// </summary>
        private ICommand _copyPlainTextcommand;
        public ICommand CopyPlainTextCommand
        {
            get
            {
                return _copyPlainTextcommand ?? (_copyPlainTextcommand = new Command(p => _worker.RunWorkerAsync(TextFormat.Text), q => SelectedPost != null && _textFormat != TextFormat.Text && !this._worker.IsBusy));
            }
        }

        /// <summary>
        /// Gets the command object of Copy of XML Content
        /// </summary>
        private ICommand _copyXmLcommand;
        public ICommand CopyJsonxmlCommand
        {
            get
            {
                return _copyXmLcommand ?? (_copyXmLcommand = new Command(p => _worker.RunWorkerAsync(TextFormat.Xml), q => SelectedPost != null && _textFormat != TextFormat.Xml && !this._worker.IsBusy));
            }
        }

        /// <summary>
        /// Gets the command object of Copy of HTML Content
        /// </summary>
        private ICommand _copyHtmlcommand;
        public ICommand CopyJsonhtmlCommand
        {
            get
            {
                return _copyHtmlcommand ?? (_copyHtmlcommand = new Command(p => _worker.RunWorkerAsync(TextFormat.Html), q => SelectedPost != null && _textFormat != TextFormat.Html && !this._worker.IsBusy));
            }
        }
        
        /// <summary>
        /// Gets the command object to Fetch the API Content
        /// </summary>
        private ICommand _clickFetchcommand;
        public ICommand FetchCommand
        {
            get
            {
                return _clickFetchcommand ?? (_clickFetchcommand = new Command(p => Fetch(), q => CanExecuteFetch()));
            }
        }

        /// <summary>
        /// Gets the command object to Close the Application.
        /// </summary>
        private ICommand _closecommand;
        public ICommand CloseApplicationCommand
        {
            get
            {
                return _closecommand ?? (_closecommand = new Command(p =>  Application.Current.Shutdown(), q => true));
            }
        }

        /// <summary>
        /// Gets the command object to Clear the Data Grid.
        /// </summary>
        private ICommand _clearcommand;
        public ICommand ClearDataGridCommand
        {
            get
            {
                return _clearcommand ?? (_clearcommand = new Command(p => this.Clear(), q => CanExecuteClear()));
            }
        }

        #endregion
 
    }
}
