using System.ComponentModel;

namespace PostViewerTool.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the event handler that handles the changes in property that is binded with the XAML control. 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raised the event that handles the changes in property that is binded with the XAML control. 
        /// </summary>
        /// <param name="propertyname"> The Property Name</param>
        protected void RaisePropertyChanged(string propertyname)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
