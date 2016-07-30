using System.Windows;
using System.Net;

namespace PostViewerTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Manages the unhandled execption
        /// </summary>
        private void ApplicationDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string message = e.Exception.Message;
            if (e.Exception.InnerException != null)
            {
                message = e.Exception.InnerException.Message;
            }
            if (e.Exception.InnerException is WebException)
            {
                message = PostViewerTool.Properties.Resources.ExceptionMessage_AccessdeniedInvalidURLstring;
            }

            MessageBox.Show(message, PostViewerTool.Properties.Resources.Application_titlestring, MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
              
    }
}
