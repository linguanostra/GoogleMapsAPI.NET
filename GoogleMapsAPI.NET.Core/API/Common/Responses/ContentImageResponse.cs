using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageProcessor;

namespace GoogleMapsAPI.NET.API.Common.Responses
{

    /// <summary>
    /// Content image response
    /// </summary>
    public abstract class ContentImageResponse : ContentBinaryResponse
    {

        #region Properties

        /// <summary>
        /// Image
        /// </summary>
        public Image Image { get; protected set; }

        /// <summary>
        /// Image format
        /// </summary>
        public ImageFormat ImageFormat { get; protected set; }

        /// <summary>
        /// Image file extension
        /// </summary>
        public string ImageFileExtension { get; protected set; }

        /// <summary>
        /// Image factory
        /// </summary>
        protected ImageFactory Factory { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance
        /// </summary>
        protected ContentImageResponse()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="content">Content bytes</param>
        protected ContentImageResponse(byte[] content) : base(content)
        {            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize image factory
        /// </summary>
        protected void InitImageFactory()
        {
            
            // Check if factory has already been initialized
            if (Factory != null) return;

            // Create new instance
            Factory = new ImageFactory();

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Populate response using content
        /// </summary>
        protected override void Populate()
        {

            // Ensure content bytes are set
            if (Content == null) return;

            // Initialize image factory
            InitImageFactory();

            // Load image from bytes
            Factory.Load(Content);

            // Assign it to instance
            Image = Factory.Image;
            ImageFormat = Factory.CurrentImageFormat.ImageFormat;
            ImageFileExtension = Factory.CurrentImageFormat.DefaultExtension;

        }

        /// <summary>
        /// Save content
        /// </summary>
        /// <param name="path">Path</param>
        public override void SaveContent(string path)
        {
            
            File.WriteAllBytes(path, Content);

        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public override void Dispose()
        {

            // Call base method
            base.Dispose();

            // Dispose of the image and factory
            Image?.Dispose();
            Factory?.Dispose();            

        }

        #endregion

    }
}