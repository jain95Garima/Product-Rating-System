using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Rating
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AverageRatingSystem",
                routeTemplate: "api/AverageRating/{id}",
                defaults: new
                {
                 controller = "ProductRatings",
                 action = "AverageProductRating",
                 id = RouteParameter.Optional,
                 }
            );

            config.Routes.MapHttpRoute(
                name: "RatingSystem",
                routeTemplate: "api/ProductRating/{id}",
                defaults: new
                {
                    controller = "ProductRatings",
                    action = "ProductRating",
                    id = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
               name: "ProductRatingByCustomer",
               routeTemplate: "api/ProductRatingByCustomer/{productId}/{userId}",
               defaults: new
               {
                   controller = "ProductRatings",
                   action = "ProductRatingByCustomer",
                   productId = RouteParameter.Optional,
                   userId = RouteParameter.Optional,
               }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
