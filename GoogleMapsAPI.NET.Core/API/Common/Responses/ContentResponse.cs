namespace GoogleMapsAPI.NET.API.Common.Responses
{

    /// <summary>
    /// Content response
    /// </summary>
    /// <typeparam name="TData">Data type</typeparam>
    public abstract class ContentResponse<TData> : Response
    {

        #region Properties

        /// <summary>
        /// Response content
        /// </summary>
        public TData Content { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Set response content
        /// </summary>
        /// <param name="content">Response content</param>
        public void SetContent(TData content)
        {

            // Assign content
            Content = content;

            // Populate instance
            Populate();

        }

        /// <summary>
        /// Update content
        /// </summary>
        /// <param name="content">Content</param>
        public void UpdateContent(TData content)
        {

            // Assign content
            Content = content;

        }

        #endregion

        #region Abstract methods

        /// <summary>
        /// Save content
        /// </summary>
        /// <param name="path">Path</param>
        public abstract void SaveContent(string path);

        #endregion

        #region Virtual methods

        /// <summary>
        /// Populate response using content
        /// </summary>
        protected virtual void Populate()
        {            
        }

        #endregion

    }
}