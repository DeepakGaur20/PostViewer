namespace ServiceAPI
{
    /// <summary>
    /// Provides the load text from API that provides the text of Complete API & element wise. 
    /// </summary>
   public interface IServiceApi
    {
        /// <summary>
        /// Returns the text of API
        /// </summary>
        /// <returns>text of API</returns>
        string GetAll();

        /// <summary>
        /// Returns the text of a specific element
        /// </summary>
        /// <param name="id">Id that require to fetch the text</param>
        /// <returns>text of a specific element </returns>
        string GetById(string id);
    }
}
