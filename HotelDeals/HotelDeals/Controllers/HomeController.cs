using Microsoft.AspNetCore.Mvc;
using HotelDeals.Models;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using System;
using NLog;

namespace HotelDeals.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public IActionResult Index()
        {
            var urlBuilder = new StringBuilder();

            urlBuilder.Append("https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel");

            Filters filters = new Filters();

            //loop throght parameters sent by the filters form, only add parameters with none empty values to expedia's url
            foreach (var param in Request.Query.Keys)
            {
                var key = param;
                Microsoft.Extensions.Primitives.StringValues value;
                if (Request.Query.TryGetValue(key, out value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        urlBuilder.AppendFormat("&{0}={1}", key, value);

                        //fill the filters objects in the view model to be reset form inputs
                        if (key.Equals("destinationCity"))
                        {
                            filters.DestinationCity = value;
                        }
                        else if (key.Equals("lengthOfStay"))
                        {
                            filters.LengthOfStay = value;
                        }
                        else if (key.Equals("minTripStartDate"))
                        {
                            filters.MinStartDate = value;
                        }
                        else if (key.Equals("maxTripStartDate"))
                        {
                            filters.MaxStartDate = value;
                        }
                        else if (key.Equals("minStarRating"))
                        {
                            int intValue;
                            if (int.TryParse(value, out intValue))
                            {
                                filters.MinStarRating = intValue;
                            }
                        }
                        else if (key.Equals("maxStarRating"))
                        {
                            int intValue;
                            if (int.TryParse(value, out intValue))
                            {
                                filters.MaxStarRating = intValue;
                            }
                        }
                    }
                }
            }

            var url = urlBuilder.ToString();

            using (var webClient = new WebClient())
            {
                var jsonString = webClient.DownloadString(url);

                var hotelDealsModel = HotelDealsModel.FromJson(jsonString);
                hotelDealsModel.Filters = filters;

                return View(hotelDealsModel);
            }
        }

        public IActionResult Error()
        {
            /* A global error handling is being used instead of a try-catch approach
             * in the occurrence of an exception, the application is redirected to this action,
             * the exception will be logged in a file and a generic error view will be shown the user
             */

            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                // Get the exception that occurred
                Exception exceptionThatOccurred = exceptionFeature.Error;

                Logger.Error(exceptionThatOccurred, exceptionThatOccurred.Message);
            }

            return View();
        }
    }
}