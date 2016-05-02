.NET client library for Google Maps API Web Services
====================================

## Description

This library brings the [Google Maps API Web Services] to your .NET application.

The .NET client library for Google Maps API Web Services is a .NET Client library for the following Google Maps
APIs:

 - [Directions API]
 - [Distance Matrix API]
 - [Elevation API]
 - [Geocoding API]
 - [Time Zone API]
 - [Roads API]
 - [Places API]
 - [Street View Image API]

Keep in mind that the same [terms and conditions](https://developers.google.com/maps/terms) apply
to usage of the APIs when they're accessed through this library.

## Support

This library was ported from the community supported [Python client library for Google Maps API Web Services](https://github.com/googlemaps/google-maps-services-python).

All the features of the Python library, in addition to the tests have been ported to this library as well.

Since it's a new release, proper testing should be done to ensure it's stable enough to use in real production applications.

If you find a bug, or have a feature suggestion, please [log an issue][issues]. If you'd like to
contribute, please read [How to Contribute][contrib].

This library is not endorsed by Google.

## Requirements

 - .NET Framework 4.0 or later
 - A Google Maps API key.

### API keys

Each Google Maps Web Service requires an API key or Client ID. API keys are
freely available with a Google Account at https://developers.google.com/console.
To generate a server key for your project:

 1. Visit https://developers.google.com/console and log in with
    a Google Account.
 1. Select an existing project, or create a new project.
 1. Click **Enable an API**.
 1. Browse for the API, and set its status to "On". The Python Client for Google Maps Services
    accesses the following APIs:
    * Directions API
    * Distance Matrix API
    * Elevation API
    * Geocoding API
    * Time Zone API
    * Roads API
    * Street View Image API
 1. Once you've enabled the APIs, click **Credentials** from the left navigation of the Developer
    Console.
 1. In the "Public API access", click **Create new Key**.
 1. Choose **Server Key**.
 1. If you'd like to restrict requests to a specific IP address, do so now.
 1. Click **Create**.

Your API key should be 40 characters long, and begin with `AIza`.

**Important:** This key should be kept secret on your server.

## Installation

#### Using Nuget

    Install-Package GoogleMapsAPI.NET

#### Cloning sources

    git clone https://github.com/linguanostra/GoogleMapsAPI.NET.git

## Developer Documentation

View the [reference documentation](https://googlemaps.github.io/google-maps-services-python/docs/2.4.3/)

Additional documentation for the included web services is available at
https://developers.google.com/maps/.

 - [Directions API]
 - [Distance Matrix API]
 - [Elevation API]
 - [Geocoding API]
 - [Time Zone API]
 - [Roads API]
 - [Places API]
 - [Street View Image API]

## Usage

This example uses the [Geocoding API] and the [Directions API].

```csharp

// Get client
var client = new MapsAPIClient("Add Your Key here");

// Geocoding an address
var geocodeResult = client.Geocoding.Geocode("1600 Amphitheatre Parkway, Mountain View, CA");

// Look up an address with reverse geocoding
var reverseGeocodeResult = client.Geocoding.ReverseGeocode(40.714224, -73.961452);

// Request directions via public transit
var directionsResult = client.Directions.GetDirections("Sydney Town Hall",
    "Parramatta, NSW",
    mode: TransportationModeEnum.Transit,
    departureTime: DateTime.Now);

```

For more usage examples, check out [the tests](test/).

## Features

### Retry on Failure

Automatically retry when intermittent failures occur. That is, when any of the retriable 5xx errors are returned from the API.

### Keys *and* Client IDs

Maps API for Work customers can use their [client ID and secret][clientid] to authenticate. Free
customers can use their [API key][apikey], too.

## Building the Project

The solution `GoogleMapsAPI.NET.sln` was made with Visual Studio 2015. It's Nuget-enabled, the required packages should restore automatically when building.

[apikey]: https://developers.google.com/maps/faq#keysystem
[clientid]: https://developers.google.com/maps/documentation/business/webservices/auth

[Google Maps API Web Services]: https://developers.google.com/maps/documentation/webservices/
[Directions API]: https://developers.google.com/maps/documentation/directions/
[Distance Matrix API]: https://developers.google.com/maps/documentation/distancematrix/
[Elevation API]: https://developers.google.com/maps/documentation/elevation/
[Geocoding API]: https://developers.google.com/maps/documentation/geocoding/
[Time Zone API]: https://developers.google.com/maps/documentation/timezone/
[Roads API]: https://developers.google.com/maps/documentation/roads/
[Places API]: https://developers.google.com/places/
[Street View Image API]: https://developers.google.com/maps/documentation/streetview/

[issues]: https://github.com/linguanostra/GoogleMapsAPI.NET/issues
[contrib]: https://github.com/linguanostra/GoogleMapsAPI.NET
