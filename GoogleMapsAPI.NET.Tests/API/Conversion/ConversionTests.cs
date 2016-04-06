using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GoogleMapsAPI.NET.API.Common.Components;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.Requests;
using GoogleMapsAPI.NET.Tests.API.Common;
using GoogleMapsAPI.NET.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsAPI.NET.Tests.API.Conversion
{

    /// <summary>
    /// Conversion tests
    /// </summary>
    [TestClass]
    public class ConversionTests : APITests
    {

        #region Test methods

        /// <summary>
        /// Test latitude/longitude
        /// </summary>
        [TestMethod]
        public void TestLatLng()
        {

            // Single
            Converter.Location(new GeoCoordinatesLocation(1, 2)).Should().Be("1,2");
            
            // List
            Converter.Location(new List<Location>
            {
                new GeoCoordinatesLocation(1, 2)
            }).Should().Be("1,2");

        }

        /// <summary>
        /// Test location list
        /// </summary>
        [TestMethod]
        public void TestLocationList()
        {

            Converter.Location(new List<Location>
            {
                new GeoCoordinatesLocation(1, 2),
                new GeoCoordinatesLocation(1, 2)
            }).Should().Be("1,2|1,2");

            Converter.Location(new List<Location>
            {
                new GeoCoordinatesLocation(1, 2),
                new AddressLocation("Quebec City")
            }).Should().Be("1,2|Quebec City");

            Converter.Location(new List<Location>
            {
                new GeoCoordinatesLocation(1, 2),
                new AddressLocation("Quebec City"),
                new PlaceLocation("12345")
            }).Should().Be("1,2|Quebec City|place_id: 12345");

        }

        /// <summary>
        /// Test join list
        /// </summary>
        [TestMethod]
        public void TestJoinList()
        {

            // Assertions
            Converter.JoinList(new[] {"asdf"}).Should().Be("asdf");

            Converter.JoinList(new[] {"1", "2", "A"}, ',').Should().Be("1,2,A");

            Converter.JoinList(new[] { "" }).Should().Be("");

            Converter.JoinList(new[] { "a", "B" }, ',').Should().Be("a,B");

        }

        /// <summary>
        /// Test time
        /// </summary>
        [TestMethod]
        public void TestTime()
        {

            Converter.Time(1409810596).Should().Be("1409810596");

            Converter.Time(new DateTime(2014, 9, 4, 6, 3, 16, DateTimeKind.Utc)).Should().Be("1409810596");

        }

        /// <summary>
        /// Test components
        /// </summary>
        [TestMethod]
        public void TestComponents()
        {

            Converter.Components(new ComponentsFilter
            {
                ["country"] = "US"
            }).Should().Be("country:US");

            Converter.Components(new ComponentsFilter
            {
                ["country"] = "US",
                ["foo"] = "1"
            }).Should().Be("country:US|foo:1");            

        }

        /// <summary>
        /// Test bounds
        /// </summary>
        [TestMethod]
        public void TestBounds()
        {

            Converter.Bounds(new ViewportBoundingBox(
                new GeoCoordinatesLocation(3, 4),
                new GeoCoordinatesLocation(1, 2)))
                .Should().Be("3,4|1,2");           

        }

        /// <summary>
        /// Test decode polyline
        /// </summary>
        [TestMethod]
        public void TestPolylineDecode()
        {

            // Set polyline
            var polyline = ("rvumEis{y[`NsfA~tAbF`bEj^h{@{KlfA~eA~`AbmEghAt~D|e@j" +
                            "lRpO~yH_\\v}LjbBh~FdvCxu@`nCplDbcBf_B|wBhIfhCnqEb~D~" +
                            "jCn_EngApdEtoBbfClf@t_CzcCpoEr_Gz_DxmAphDjjBxqCviEf}" +
                            "B|pEvsEzbE~qGfpExjBlqCx}BvmLb`FbrQdpEvkAbjDllD|uDldD" +
                            "j`Ef|AzcEx_Gtm@vuI~xArwD`dArlFnhEzmHjtC~eDluAfkC|eAd" +
                            "hGpJh}N_mArrDlr@h|HzjDbsAvy@~~EdTxpJje@jlEltBboDjJdv" +
                            "KyZpzExrAxpHfg@pmJg[tgJuqBnlIarAh}DbN`hCeOf_IbxA~uFt" +
                            "|A|xEt_ArmBcN|sB|h@b_DjOzbJ{RlxCcfAp~AahAbqG~Gr}AerA" +
                            "`dCwlCbaFo]twKt{@bsG|}A~fDlvBvz@tw@rpD_r@rqB{PvbHek@" +
                            "vsHlh@ptNtm@fkD[~xFeEbyKnjDdyDbbBtuA|~Br|Gx_AfxCt}Cj" +
                            "nHv`Ew\\lnBdrBfqBraD|{BldBxpG|]jqC`mArcBv]rdAxgBzdEb" +
                            "{InaBzyC}AzaEaIvrCzcAzsCtfD~qGoPfeEh]h`BxiB`e@`kBxfA" +
                            "v^pyA`}BhkCdoCtrC~bCxhCbgEplKrk@tiAteBwAxbCwuAnnCc]b" +
                            "{FjrDdjGhhGzfCrlDruBzSrnGhvDhcFzw@n{@zxAf}Fd{IzaDnbD" +
                            "joAjqJjfDlbIlzAraBxrB}K~`GpuD~`BjmDhkBp{@r_AxCrnAjrC" +
                            "x`AzrBj{B|r@~qBbdAjtDnvCtNzpHxeApyC|GlfM`fHtMvqLjuEt" +
                            "lDvoFbnCt|@xmAvqBkGreFm~@hlHw|AltC}NtkGvhBfaJ|~@riAx" +
                            "uC~gErwCttCzjAdmGuF`iFv`AxsJftD|nDr_QtbMz_DheAf~Buy@" +
                            "rlC`i@d_CljC`gBr|H|nAf_Fh{G|mE~kAhgKviEpaQnu@zwAlrA`" +
                            "G~gFnvItz@j{Cng@j{D{]`tEftCdcIsPz{DddE~}PlnE|dJnzG`e" +
                            "G`mF|aJdqDvoAwWjzHv`H`wOtjGzeXhhBlxErfCf{BtsCjpEjtD|" +
                            "}Aja@xnAbdDt|ErMrdFh{CzgAnlCnr@`wEM~mE`bA`uD|MlwKxmB" +
                            "vuFlhB|sN`_@fvBp`CxhCt_@loDsS|eDlmChgFlqCbjCxk@vbGxm" +
                            "CjbMba@rpBaoClcCk_DhgEzYdzBl\\vsA_JfGztAbShkGtEhlDzh" +
                            "C~w@hnB{e@yF}`D`_Ayx@~vGqn@l}CafC");

            // Decode points
            var points = Converter.DecodePolyline(polyline);

            // Assertions
            points[0].Latitude.Should().BeApproximately(-33.86746, 1);
            points[0].Longitude.Should().BeApproximately(151.207090, 1);
            points.ElementAt(points.Count - 1).Latitude.Should().BeApproximately(-37.814130, 1);
            points.ElementAt(points.Count - 1).Longitude.Should().BeApproximately(144.963180, 1);

        }

        /// <summary>
        /// Test polyline round trip
        /// </summary>
        [TestMethod]
        public void TestPolylineRoundTrip()
        {

            // Set polyline
            var testPolyline = "gcneIpgxzRcDnBoBlEHzKjBbHlG`@`IkDxIi" +
                               "KhKoMaLwTwHeIqHuAyGXeB~Ew@fFjAtIzExF";

            // Decode it
            var points = Converter.DecodePolyline(testPolyline);

            // Encode it again
            var actualPolyline = Converter.EncodePolyline(points);

            // Assertions
            testPolyline.Should().Be(actualPolyline);

        }

        /// <summary>
        /// Test enum flags list
        /// </summary>
        [TestMethod]
        public void TestEnumFlagsList()
        {

            // Set avoidable features
            var avoidableFeatures = AvoidFeaturesEnum.Tolls | AvoidFeaturesEnum.Indoors;

            // Assertions
            Converter.EnumFlagsList(avoidableFeatures).Should().Be("indoors|tolls");

        }

        /// <summary>
        /// Test invalid enum flags list
        /// </summary>
        [TestMethod]
        public void TestInvalidEnumFlagsList()
        {

            // Set traffic model (no Flags type enum, should not combine)
            var trafficModel = TrafficModelEnum.Pessimistic | TrafficModelEnum.Optimistic;

            // Assertions
            Converter.EnumFlagsList(trafficModel).Should().NotBe("optimistic|pessimistic");

        }

        #endregion

    }
}