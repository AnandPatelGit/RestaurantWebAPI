using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using RestaurantDataAccess;

namespace RestaurantWebAPI.Controllers
{
    public class RestaurantsController : ApiController
    {
        public HttpResponseMessage Get() {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities()) {
               var rest =  entities.Restaurants.ToList();
                return Request.CreateResponse(HttpStatusCode.OK,rest);
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
            {
                var restaurant = entities.Restaurants.FirstOrDefault(e=>e.restaurantId == id);
                return Request.CreateResponse(HttpStatusCode.OK, restaurant);
            }
        }

        public HttpResponseMessage Get(string restaurantCuisineType)
        {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
            {
                var restaurant = entities.Restaurants.
                    Where(e => e.restaurantCuisineType == restaurantCuisineType).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, restaurant);
            }
        }

        public HttpResponseMessage GetClosingTime(string restaurantCloseTime)
        {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
            {
                var restaurant = entities.Restaurants.Where(e => e.restaurantClosingTime == restaurantCloseTime).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, restaurant);
            }
        }

        public HttpResponseMessage GetCity(string restaurantCity)
        {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
            {
                var restaurant = entities.Restaurants.Where(e => e.restaurantCity == restaurantCity).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, restaurant);
            }
        }

        public HttpResponseMessage Post([FromBody] Restaurant restaurant) {
            try
            {
                using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, restaurant);
                    message.Headers.Location = new Uri(Request.RequestUri +
                    restaurant.restaurantId.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Get(string restaurantCuisineType, string restaurantCloseTime)
        {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
            {
                var restaurant = entities.Restaurants.Where(e => e.restaurantCuisineType == restaurantCuisineType && e.restaurantClosingTime == restaurantCloseTime).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, restaurant);
            }
        }

        public HttpResponseMessage GetCuisinesAndCity(string restaurantCuisineType, string restaurantCity)
        {
            using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
            {
                var restaurant = entities.Restaurants.Where(e => e.restaurantCuisineType == restaurantCuisineType && e.restaurantCity == restaurantCity).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, restaurant);
            }
        }

        public HttpResponseMessage Delete(int id) {
            try
            {
                using (RestaurantWebAPI20180109074303_dbEntities entities = new RestaurantWebAPI20180109074303_dbEntities())
                {
                    var entity = entities.Restaurants.FirstOrDefault(e => e.restaurantId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Restaurant with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Restaurants.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}