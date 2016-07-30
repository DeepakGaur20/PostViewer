using System;
using NUnit.Framework;
using PostViewerTool.Properties;

namespace PostViewerTool.Utility._Nunit
{
    /// <summary>
    /// Nunits for Conversion that is a Utility Class 
    /// </summary>
    [TestFixture]
    public class ConversionTest
    {
        /// <summary>
        /// Represents the text of Selected Post
        /// </summary>
        private readonly string _jsoncontent = "{" + Environment.NewLine + Resources.Post_UserIdstring + Environment.NewLine + Resources.Post_postidstring + Environment.NewLine + Resources.Post_Titlestring + Environment.NewLine + Resources.Post_bodystring + Environment.NewLine + " }";
        
        /// <summary>
        /// Test the ToXml()
        /// </summary>
        [Test]
        public void TestToXml()
        {
            string xmltext = Conversion.ToXml(_jsoncontent);
            Assert.IsNotNullOrEmpty(xmltext);
        }

        /// <summary>
        /// Test the ToXml() for empty argument
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToXml_emptyinput()
        {
            Conversion.ToXml(string.Empty);
        }

        /// <summary>
        /// Test the ToXml() for null argument
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToXml_null()
        {
            Conversion.ToXml(null);
        }

        /// <summary>
        /// Test the ToHtml()
        /// </summary>
        [Test]
        public void TestToHtml()
        {
            string xmltext = Conversion.ToHtml(_jsoncontent);
            Assert.IsNotNullOrEmpty(xmltext);
        }

        /// <summary>
        /// Test the ToHtml() for empty argument
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToHtml_emptyinput()
        {
            Conversion.ToHtml(string.Empty);
        }

        /// <summary>
        /// Test the ToHtml() for null argument
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToHtml_null()
        {
            Conversion.ToHtml(null);
        }
    }
}
