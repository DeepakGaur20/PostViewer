using System.Windows;
using System.Windows.Media.Imaging;
using System;

namespace PostViewerTool.Utility
{
    /// <summary>
    /// This class has the kind of Imagepath properties that needed in overall project
    /// </summary>
    static class ImageSource
    {
        #region Images Path Objects

       /// <summary>
        /// Represents the String to hold the application resource that controls can bind to
       /// </summary>
        private static readonly string ApplicationNameComponent = $"/{Application.ResourceAssembly.FullName};component/";

         /// <summary>
        /// Represents the String to hold image path
         /// </summary>
         private static readonly string ImageResourcesPath = ApplicationNameComponent + "/Resources/Images/";

         /// <summary>
         /// Gets the image path for Main Window
         /// </summary>
         public static BitmapImage ImageMain => new BitmapImage(new Uri(ImageResourcesPath + "Post.ico", UriKind.Relative));

        /// <summary>
         /// Gets the image path for Fetch Button
         /// </summary>
         public static BitmapImage ImageFetch => new BitmapImage(new Uri(ImageResourcesPath + "Fetch.jpg", UriKind.Relative));

        /// <summary>
         /// Gets the image path for Close Button
         /// </summary>
         public static BitmapImage ImageClose => new BitmapImage(new Uri(ImageResourcesPath + "Close.png", UriKind.Relative));

        /// <summary>
         /// Gets the image path for Clear Button
        /// </summary>
        public static BitmapImage ImageClear => new BitmapImage(new Uri(ImageResourcesPath + "Clear.png", UriKind.Relative));

        /// <summary>
        /// Gets the image path for Html Button
        /// </summary>
        public static BitmapImage ImageHtml => new BitmapImage(new Uri(ImageResourcesPath + "Html.png", UriKind.Relative));

        /// <summary>
        /// Gets the image path for Json Button
         /// </summary>
         public static BitmapImage ImageJson => new BitmapImage(new Uri(ImageResourcesPath + "Json.png", UriKind.Relative));

        /// <summary>
         /// Gets the image path for Xml Button
         /// </summary>
         public static BitmapImage ImageXml => new BitmapImage(new Uri(ImageResourcesPath + "Xml.png", UriKind.Relative));

        /// <summary>
         /// Gets the image path for Plain Button
         /// </summary>
         public static BitmapImage ImagePlain => new BitmapImage(new Uri(ImageResourcesPath + "Plain.jpg", UriKind.Relative));

        #endregion
    }
}
