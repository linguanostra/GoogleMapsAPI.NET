using System;
using System.Collections.Generic;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces.Combined;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Places.Enums;
using GoogleMapsAPI.NET.Requests;

namespace GoogleMapsAPI.NET.App
{
    
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args)
        {

            // Get client
            var client = new MapsAPIClient("---YOUR API KEY---");

            // Get directions
            var directions = client.Directions.GetDirections(
                    new AddressLocation("Chicago,IL"),
                    new AddressLocation("Los Angeles,CA"),
                    waypoints: new List<Location>
                    {
                        new AddressLocation("Joplin,MO"),
                        new AddressLocation("Oklahoma City,OK")
                    });

            // Geocode address
            var geocode = client.Geocoding.Geocode("203-1200 Saint-Jean-Baptiste, Quebec");

            // Search places nearby
            var places = client.Places.NearbySearch(
                geocode.Results[0].Geometry.Location,
                rankBy: PlaceRankByEnum.Distance,
                placeType: PlaceSearchTypeEnum.ElectronicsStore);

            // Radar search places
            var radarPlaces = client.Places.RadarSearch(
                geocode.Results[0].Geometry.Location,
                10,
                placeType: PlaceSearchTypeEnum.ATM);

            // Get timezone
            var timezone = client.TimeZone.GetTimeZone(35.27801, 149.12958, DateTime.Now);

            // Snap to roads
            var snap = client.Roads.SnapToRoads(new List<IGeoCoordinatesLocation>()
            {
                new GeoCoordinatesLocation(35.27801, 149.12958),
                new GeoCoordinatesLocation(-35.28032, 149.12907)
            });

            // Get distance matrix
            var matrix = client.DistanceMatrix.GetDistanceMatrix(
                new List<IAddressOrGeoCoordinatesLocation>
                {
                    new AddressLocation("Vancouver BC"),
                    new AddressLocation("Seattle")
                },
                new List<IAddressOrGeoCoordinatesLocation>
                {
                    new AddressLocation("San Francisco"),
                    new AddressLocation("Victoria BC")
                },
                TransportationModeEnum.Bicycling,
                language: "fr-FR");

            // Get place photo
            var resultPhoto = client.Places.GetPlacePhoto(
                "CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXePv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNpFX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmrNfeEHSGSc3FyhNLlBU",
                maxWidth: 400);

            // Autocomplete            
            var autoComplete = client.Places.AutoComplete(
                "Google",
                location: new GeoCoordinatesLocation(-33.86746, 151.207090),
                offset: 3,
                language: "en-AU",
                types: new[] {"geocode"},
                components: new ComponentsFilter {["country"] = "au"}
                );

            // Info            
            Console.WriteLine();
            Console.WriteLine(@"Press ENTER to exit...");
            Console.ReadLine();            

        }
        
    }

}
