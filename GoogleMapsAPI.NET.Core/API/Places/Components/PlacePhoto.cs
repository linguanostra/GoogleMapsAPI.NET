using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{

    /// <summary>
    /// Place photo component
    /// </summary>
    [DataContract]
    public class PlacePhoto
    {

        #region Properties

        /// <summary>
        /// String used to identify the photo when you perform a Photo request
        /// </summary>
        [DataMember(Name = "photo_reference")]
        public string PhotoReference { get; set; }

        /// <summary>
        /// Maximum height of the image.
        /// </summary>
        [DataMember(Name = "height")]
        public int Height { get; set; }

        /// <summary>
        /// Maximum width of the image.
        /// </summary>
        [DataMember(Name = "width")]
        public int Width { get; set; }

        /// <summary>
        /// Any required attributions
        /// </summary>
        [DataMember(Name = "html_attributions")]
        public List<string> HTMLAttributions { get; set; }

        #endregion
         
    }
}