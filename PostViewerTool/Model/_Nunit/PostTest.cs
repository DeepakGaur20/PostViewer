using System;
using NUnit.Framework;

namespace PostViewerTool.Model._Nunit
{
    /// <summary>
    /// Nunits for Post that is a model Class 
    /// </summary>
    [TestFixture]
    public class PostTest
    {
        /// <summary>
        /// Represents the Post
        /// </summary>
        Post _post;
        
        /// <summary>
        /// Configure and Setups all require dependecy 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _post = new Post(1, 1, "AA", "Test Body");
        }

        /// <summary>
        /// Destroys the all dependencies and Dispose the objects too.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _post = null;
        }

        /// <summary>
        /// To Test the Empty Constructor
        /// </summary>
        [Test]
        public void ConstructorTest_WithEmptyConstructor()
        {
            _post = new Post();
            Assert.IsNotNull(_post);
        }

        /// <summary>
        /// To Test the Parametersied Constructor
        /// </summary>
        [Test]
        public void ConstructorTest_2()
        {
            var postnew = new Post(2, 2, "BB", "Test Body 2");
            string expectedconst = $"User Id = '2' and Post Id = '2' {Environment.NewLine}Title = 'BB' {Environment.NewLine}Body = 'Test Body 2'";

            Assert.IsNotNull(postnew);
            Assert.AreEqual(2, postnew.Id);
            Assert.AreEqual(2, postnew.UserId);
            Assert.AreEqual("BB", postnew.Title);
            Assert.AreEqual("Test Body 2", postnew.Body);
            Assert.AreEqual(expectedconst, postnew.ToString());
        }
        
        /// <summary>
        /// Test the Id of Post
        /// </summary>
        [Test]
        public void TestId()
        {
            const int expectedconst = 1;
            Assert.AreEqual(expectedconst, _post.Id);
        }

        /// <summary>
        /// Test the User Id of Post
        /// </summary>
        [Test]
        public void TestUserId()
        {
            const int expectedconst = 1;
            Assert.AreEqual(expectedconst, _post.UserId);
        }

        /// <summary>
        /// Test the Title of Post
        /// </summary>
        [Test]
        public void TestTitle()
        {
            const string expectedconst = "AA";
            Assert.AreEqual(expectedconst, _post.Title);
        }

        /// <summary>
        /// Test the Body of Post
        /// </summary>
        [Test]
        public void TestBody()
        {
            const string expectedconst = "Test Body";
            Assert.AreEqual(expectedconst, _post.Body);
        }

        /// <summary>
        /// Test the ToString() of Post
        /// </summary>
        [Test]
        public void Test_ToString()
        {
            string expectedconst = $"User Id = '1' and Post Id = '1' {Environment.NewLine}Title = 'AA' {Environment.NewLine}Body = 'Test Body'";
            Assert.AreEqual(expectedconst, _post.ToString());
        }
    }
}
