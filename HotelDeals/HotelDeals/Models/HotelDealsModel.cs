using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelDeals.Models
{

    public partial class HotelDealsModel
    {
        [JsonProperty("offerInfo")]
        public OfferInfo OfferInfo { get; set; }

        [JsonProperty("userInfo")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty("offers")]
        public Offers Offers { get; set; }

    }

    public partial class OfferInfo
    {
        [JsonProperty("siteID")]
        public string SiteId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("userSelectedCurrency")]
        public string UserSelectedCurrency { get; set; }
    }

    public partial class Offers
    {
        [JsonProperty("Hotel")]
        public List<Hotel> Hotel { get; set; }
    }

    public partial class Hotel
    {
        [JsonProperty("offerDateRange")]
        public OfferDateRange OfferDateRange { get; set; }

        [JsonProperty("destination")]
        public Destination Destination { get; set; }

        [JsonProperty("hotelInfo")]
        public HotelInfo HotelInfo { get; set; }

        [JsonProperty("hotelPricingInfo")]
        public HotelPricingInfo HotelPricingInfo { get; set; }

        [JsonProperty("hotelUrls")]
        public HotelUrls HotelUrls { get; set; }
    }

    public partial class Destination
    {
        [JsonProperty("regionID")]
        public string RegionId { get; set; }

        [JsonProperty("associatedMultiCityRegionId")]
        public string AssociatedMultiCityRegionId { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("tla")]
        public string Tla { get; set; }

        [JsonProperty("nonLocalizedCity")]
        public string NonLocalizedCity { get; set; }
    }

    public partial class HotelInfo
    {
        [JsonProperty("hotelId")]
        public string HotelId { get; set; }

        [JsonProperty("hotelName")]
        public string HotelName { get; set; }

        [JsonProperty("localizedHotelName")]
        public string LocalizedHotelName { get; set; }

        [JsonProperty("hotelDestination")]
        public string HotelDestination { get; set; }

        [JsonProperty("hotelDestinationRegionID")]
        public string HotelDestinationRegionId { get; set; }

        [JsonProperty("hotelLongDestination")]
        public string HotelLongDestination { get; set; }

        [JsonProperty("hotelStreetAddress")]
        public string HotelStreetAddress { get; set; }

        [JsonProperty("hotelCity")]
        public string HotelCity { get; set; }

        [JsonProperty("hotelProvince")]
        public string HotelProvince { get; set; }

        [JsonProperty("hotelCountryCode")]
        public string HotelCountryCode { get; set; }

        [JsonProperty("hotelLatitude")]
        public double HotelLatitude { get; set; }

        [JsonProperty("hotelLongitude")]
        public double HotelLongitude { get; set; }

        [JsonProperty("hotelStarRating")]
        public string HotelStarRating { get; set; }

        [JsonProperty("hotelGuestReviewRating")]
        public double HotelGuestReviewRating { get; set; }

        [JsonProperty("hotelReviewTotal")]
        public long HotelReviewTotal { get; set; }

        [JsonProperty("hotelImageUrl")]
        public string HotelImageUrl { get; set; }

        [JsonProperty("vipAccess")]
        public bool VipAccess { get; set; }

        [JsonProperty("isOfficialRating")]
        public bool IsOfficialRating { get; set; }
    }

    public partial class HotelPricingInfo
    {
        [JsonProperty("averagePriceValue")]
        public double AveragePriceValue { get; set; }

        [JsonProperty("totalPriceValue")]
        public double TotalPriceValue { get; set; }

        [JsonProperty("crossOutPriceValue")]
        public double CrossOutPriceValue { get; set; }

        [JsonProperty("originalPricePerNight")]
        public double OriginalPricePerNight { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("percentSavings")]
        public long PercentSavings { get; set; }

        [JsonProperty("drr")]
        public bool Drr { get; set; }
    }

    public partial class HotelUrls
    {
        [JsonProperty("hotelInfositeUrl")]
        public string HotelInfositeUrl { get; set; }

        [JsonProperty("hotelSearchResultUrl")]
        public string HotelSearchResultUrl { get; set; }
    }

    public partial class OfferDateRange
    {
        [JsonProperty("travelStartDate")]
        public List<long> TravelStartDate { get; set; }

        [JsonProperty("travelEndDate")]
        public List<long> TravelEndDate { get; set; }

        [JsonProperty("lengthOfStay")]
        public long LengthOfStay { get; set; }

        public string TravelStartDateStirng
        {
            get
            {
                if (TravelStartDate.Count < 3)
                    return string.Empty;
                return string.Format("{0}-{1}-{2}", TravelStartDate[2], TravelStartDate[1], TravelStartDate[0]);
            }
        }

        public string TravelEndDateStirng
        {
            get
            {
                if (TravelEndDate.Count < 3)
                    return string.Empty;
                return string.Format("{0}-{1}-{2}", TravelEndDate[2], TravelEndDate[1], TravelEndDate[0]);
            }
        }
    }

    public partial class UserInfo
    {
        [JsonProperty("persona")]
        public Persona Persona { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class Persona
    {
        [JsonProperty("personaType")]
        public string PersonaType { get; set; }
    }

    public partial class HotelDealsModel
    {
        public static HotelDealsModel FromJson(string json) => JsonConvert.DeserializeObject<HotelDealsModel>(json, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
