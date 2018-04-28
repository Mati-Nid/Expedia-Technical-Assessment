using Microsoft.AspNetCore.Mvc;
using HotelDeals.Models;
using System.Net;
using System.Text;

namespace HotelDeals.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var urlBuilder = new StringBuilder();

            urlBuilder.Append("https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel");

            Filters filters = new Filters();

            foreach(var param in Request.Query.Keys)
            {
                var key = param;
                Microsoft.Extensions.Primitives.StringValues value;
                if(Request.Query.TryGetValue(key, out value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        urlBuilder.AppendFormat("&{0}={1}",key,value);

                        if (key.Equals("destinationCity"))
                        {
                            filters.DestinationCity = value;
                        }else if (key.Equals("lengthOfStay"))
                        {
                            filters.LengthOfStay = value;
                        }else if (key.Equals("minTripStartDate"))
                        {
                            filters.MinStartDate = value;
                        }else if (key.Equals("maxTripStartDate"))
                        {
                            filters.MaxStartDate = value;
                        }else if (key.Equals("minStarRating"))
                        {
                            filters.MinStarRating = value;
                        }else if (key.Equals("maxStarRating"))
                        {
                            filters.MaxStarRating = value;
                        }
                    }
                }
            }

            var url = urlBuilder.ToString();

            using (var webClient = new WebClient())
            {
                //sync request
                var jsonString = webClient.DownloadString(url);

                var hotelDealsModel = HotelDealsModel.FromJson(jsonString);
                hotelDealsModel.Filters = filters;

                return View(hotelDealsModel);
            }
        }
    }
}