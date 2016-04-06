using System;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Enums
{

    /// <summary>
    /// Place search type enum
    /// </summary>
    public enum PlaceSearchTypeEnum
    {
        /// <summary>
        /// Accounting
        /// </summary>
        [EnumMember(Value = "accounting")]
        Accounting,
        /// <summary>
        /// Airport
        /// </summary>
        [EnumMember(Value = "airport")]
        Airport,
        /// <summary>
        /// Amusement park
        /// </summary>
        [EnumMember(Value = "amusement_park")]
        AmusementPark,
        /// <summary>
        /// Aquarium
        /// </summary>
        [EnumMember(Value = "aquarium")]
        Aquarium,
        /// <summary>
        /// Art gallery
        /// </summary>
        [EnumMember(Value = "art_gallery")]
        ArtGallery,
        /// <summary>
        /// ATM
        /// </summary>
        [EnumMember(Value = "atm")]
        ATM,
        /// <summary>
        /// Bakery
        /// </summary>
        [EnumMember(Value = "bakery")]
        Bakery,
        /// <summary>
        /// Bank
        /// </summary>
        [EnumMember(Value = "bank")]
        Bank,
        /// <summary>
        /// Bar
        /// </summary>
        [EnumMember(Value = "bar")]
        Bar,
        /// <summary>
        /// Beauty salon
        /// </summary>
        [EnumMember(Value = "beauty_salon")]
        BeautySalon,
        /// <summary>
        /// Bicycle store
        /// </summary>
        [EnumMember(Value = "bicycle_store")]
        BicycleStore,
        /// <summary>
        /// Book store
        /// </summary>
        [EnumMember(Value = "book_store")]
        BookStore,
        /// <summary>
        /// Bowling alley
        /// </summary>
        [EnumMember(Value = "bowling_alley")]
        BowlingAlley,
        /// <summary>
        /// Bus station
        /// </summary>
        [EnumMember(Value = "bus_station")]
        BusStation,
        /// <summary>
        /// Cafe
        /// </summary>
        [EnumMember(Value = "cafe")]
        Cafe,
        /// <summary>
        /// Campground
        /// </summary>
        [EnumMember(Value = "campground")]
        Campground,
        /// <summary>
        /// Car dealer
        /// </summary>
        [EnumMember(Value = "car_dealer")]
        CarDealer,
        /// <summary>
        /// Car rental
        /// </summary>
        [EnumMember(Value = "car_rental")]
        CarRental,
        /// <summary>
        /// Car repair
        /// </summary>
        [EnumMember(Value = "car_repair")]
        CarRepair,
        /// <summary>
        /// Car wash
        /// </summary>
        [EnumMember(Value = "car_wash")]
        CarWash,
        /// <summary>
        /// Casino
        /// </summary>
        [EnumMember(Value = "casino")]
        Casino,
        /// <summary>
        /// Cemetery
        /// </summary>
        [EnumMember(Value = "cemetery")]
        Cemetery,
        /// <summary>
        /// Church
        /// </summary>
        [EnumMember(Value = "church")]
        Church,
        /// <summary>
        /// City hall
        /// </summary>
        [EnumMember(Value = "city_hall")]
        CityHall,
        /// <summary>
        /// Clothing store
        /// </summary>
        [EnumMember(Value = "clothing_store")]
        ClothingStore,
        /// <summary>
        /// convenience_store
        /// </summary>
        [EnumMember(Value = "convenience_store")]
        ConvenienceStore,
        /// <summary>
        /// courthouse
        /// </summary>
        [EnumMember(Value = "courthouse")]
        Courthouse,
        /// <summary>
        /// dentist
        /// </summary>
        [EnumMember(Value = "dentist")]
        Dentist,
        /// <summary>
        /// department_store
        /// </summary>
        [EnumMember(Value = "department_store")]
        DepartmentStore,
        /// <summary>
        /// Doctor
        /// </summary>
        [EnumMember(Value = "doctor")]
        Doctor,
        /// <summary>
        /// Electrician
        /// </summary>
        [EnumMember(Value = "electrician")]
        Electrician,
        /// <summary>
        /// electronics_store
        /// </summary>
        [EnumMember(Value = "electronics_store")]
        ElectronicsStore,
        /// <summary>
        /// Embassy
        /// </summary>
        [EnumMember(Value = "embassy")]
        Embassy,
        /// <summary>
        /// Establishment (deprecated)
        /// </summary>
        [EnumMember(Value = "establishment")]
        [Obsolete]
        Establishment,
        /// <summary>
        /// Finance (deprecated)
        /// </summary>
        [EnumMember(Value = "finance")]
        [Obsolete]
        Finance,
        /// <summary>
        /// Fire station
        /// </summary>
        [EnumMember(Value = "fire_station")]
        FireStation,
        /// <summary>
        /// Florist
        /// </summary>
        [EnumMember(Value = "florist")]
        Florist,
        /// <summary>
        /// Food (deprecated)
        /// </summary>
        [EnumMember(Value = "food")]
        [Obsolete]
        Food,
        /// <summary>
        /// Funeral home
        /// </summary>
        [EnumMember(Value = "funeral_home")]
        FuneralHome,
        /// <summary>
        /// Furniture store
        /// </summary>
        [EnumMember(Value = "furniture_store")]
        FurnitureStore,
        /// <summary>
        /// Gas station
        /// </summary>
        [EnumMember(Value = "gas_station")]
        GasStation,
        /// <summary>
        /// general_contractor (deprecated)
        /// </summary>
        [EnumMember(Value = "general_contractor")]
        [Obsolete]
        GeneralContractor,
        /// <summary>
        /// Grocery or supermarket
        /// </summary>
        [EnumMember(Value = "grocery_or_supermarket")]
        GroceryOrSupermarket,
        /// <summary>
        /// Gym
        /// </summary>
        [EnumMember(Value = "gym")]
        Gym,
        /// <summary>
        /// Hair care
        /// </summary>
        [EnumMember(Value = "hair_care")]
        HairCare,
        /// <summary>
        /// Hardware store
        /// </summary>
        [EnumMember(Value = "hardware_store")]
        HardwareStore,
        /// <summary>
        /// health (deprecated)
        /// </summary>
        [EnumMember(Value = "health")]
        [Obsolete]
        Health,
        /// <summary>
        /// Hindu temple
        /// </summary>
        [EnumMember(Value = "hindu_temple")]
        HinduTemple,
        /// <summary>
        /// Home goods store
        /// </summary>
        [EnumMember(Value = "home_goods_store")]
        HomeGoodsStore,
        /// <summary>
        /// Hospital
        /// </summary>
        [EnumMember(Value = "hospital")]
        Hospital,
        /// <summary>
        /// Insurance agency
        /// </summary>
        [EnumMember(Value = "insurance_agency")]
        InsuranceAgency,
        /// <summary>
        /// Jewelry store
        /// </summary>
        [EnumMember(Value = "jewelry_store")]
        JewelryStore,
        /// <summary>
        /// Laundry
        /// </summary>
        [EnumMember(Value = "laundry")]
        Laundry,
        /// <summary>
        /// Lawyer
        /// </summary>
        [EnumMember(Value = "lawyer")]
        Lawyer,
        /// <summary>
        /// Library
        /// </summary>
        [EnumMember(Value = "library")]
        Library,
        /// <summary>
        /// Liquor store
        /// </summary>
        [EnumMember(Value = "liquor_store")]
        LiquorStore,
        /// <summary>
        /// Local government office
        /// </summary>
        [EnumMember(Value = "local_government_office")]
        LocalGovernmentOffice,
        /// <summary>
        /// Locksmith
        /// </summary>
        [EnumMember(Value = "locksmith")]
        Locksmith,
        /// <summary>
        /// Lodging
        /// </summary>
        [EnumMember(Value = "lodging")]
        Lodging,
        /// <summary>
        /// Meal delivery
        /// </summary>
        [EnumMember(Value = "meal_delivery")]
        MealDelivery,
        /// <summary>
        /// Meal takeaway
        /// </summary>
        [EnumMember(Value = "meal_takeaway")]
        MealTakeaway,
        /// <summary>
        /// Mosque
        /// </summary>
        [EnumMember(Value = "mosque")]
        Mosque,
        /// <summary>
        /// Movie rental
        /// </summary>
        [EnumMember(Value = "movie_rental")]
        MovieRental,
        /// <summary>
        /// Movie theater
        /// </summary>
        [EnumMember(Value = "movie_theater")]
        MovieTheater,
        /// <summary>
        /// Moving company
        /// </summary>
        [EnumMember(Value = "moving_company")]
        MovingCompany,
        /// <summary>
        /// Museum
        /// </summary>
        [EnumMember(Value = "museum")]
        Museum,
        /// <summary>
        /// Night club
        /// </summary>
        [EnumMember(Value = "night_club")]
        NightClub,
        /// <summary>
        /// Painter
        /// </summary>
        [EnumMember(Value = "painter")]
        Painter,
        /// <summary>
        /// Park
        /// </summary>
        [EnumMember(Value = "park")]
        Park,
        /// <summary>
        /// Parking
        /// </summary>
        [EnumMember(Value = "parking")]
        Parking,
        /// <summary>
        /// Pet store
        /// </summary>
        [EnumMember(Value = "pet_store")]
        PetStore,
        /// <summary>
        /// Pharmacy
        /// </summary>
        [EnumMember(Value = "pharmacy")]
        Pharmacy,
        /// <summary>
        /// Physiotherapist
        /// </summary>
        [EnumMember(Value = "physiotherapist")]
        Physiotherapist,
        /// <summary>
        /// Place of worship (deprecated)
        /// </summary>
        [EnumMember(Value = "place_of_worship")]
        [Obsolete]
        PlaceOfWorship,
        /// <summary>
        /// Plumber
        /// </summary>
        [EnumMember(Value = "plumber")]
        Plumber,
        /// <summary>
        /// Police
        /// </summary>
        [EnumMember(Value = "police")]
        Police,
        /// <summary>
        /// Post office
        /// </summary>
        [EnumMember(Value = "post_office")]
        PostOffice,
        /// <summary>
        /// Real estate agency
        /// </summary>
        [EnumMember(Value = "real_estate_agency")]
        RealEstateAgency,
        /// <summary>
        /// Restaurant
        /// </summary>
        [EnumMember(Value = "restaurant")]
        Restaurant,
        /// <summary>
        /// Roofing contractor
        /// </summary>
        [EnumMember(Value = "roofing_contractor")]
        RoofingContractor,
        /// <summary>
        /// RV ppark
        /// </summary>
        [EnumMember(Value = "rv_park")]
        RVPark,
        /// <summary>
        /// School
        /// </summary>
        [EnumMember(Value = "school")]
        School,
        /// <summary>
        /// Shoe store
        /// </summary>
        [EnumMember(Value = "shoe_store")]
        ShoeStore,
        /// <summary>
        /// Shopping mall
        /// </summary>
        [EnumMember(Value = "shopping_mall")]
        ShoppingMall,
        /// <summary>
        /// Spa
        /// </summary>
        [EnumMember(Value = "spa")]
        Spa,
        /// <summary>
        /// Stadium
        /// </summary>
        [EnumMember(Value = "stadium")]
        Stadium,
        /// <summary>
        /// Storage
        /// </summary>
        [EnumMember(Value = "storage")]
        Storage,
        /// <summary>
        /// Store
        /// </summary>
        [EnumMember(Value = "store")]
        Store,
        /// <summary>
        /// Subway station
        /// </summary>
        [EnumMember(Value = "subway_station")]
        SubwayStation,
        /// <summary>
        /// Synagogue
        /// </summary>
        [EnumMember(Value = "synagogue")]
        Synagogue,
        /// <summary>
        /// Taxi stand
        /// </summary>
        [EnumMember(Value = "taxi_stand")]
        TaxiStand,
        /// <summary>
        /// Train station
        /// </summary>
        [EnumMember(Value = "train_station")]
        TrainStation,
        /// <summary>
        /// Transit station
        /// </summary>
        [EnumMember(Value = "transit_station")]
        TransitStation,
        /// <summary>
        /// Travel agency
        /// </summary>
        [EnumMember(Value = "travel_agency")]
        TravelAgency,
        /// <summary>
        /// University
        /// </summary>
        [EnumMember(Value = "university")]
        University,
        /// <summary>
        /// Veterinary care
        /// </summary>
        [EnumMember(Value = "veterinary_care")]
        VeterinaryCare,
        /// <summary>
        /// Zoo
        /// </summary>
        [EnumMember(Value = "zoo")]
        Zoo
    }
}