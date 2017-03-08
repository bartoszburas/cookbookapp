using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiServiceLayer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ShopListApi",
                routeTemplate: "api/ShopList/{userId}",
                defaults: new { controller = "ShopList", action = "Get", userId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ShopListAddApi",
                routeTemplate: "api/ShopList/{userId}/Add",
                defaults: new { controller = "ShopList", action = "Post", userId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ShopListDeleteApi",
                routeTemplate: "api/ShopList/{userId}/{ingredientName}",
                defaults: new
                {
                    controller = "ShopList",
                    action = "Delete",
                    userId = RouteParameter.Optional,
                    ingredientName = RouteParameter.Optional
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
