using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantWebAPI.Controllers
{

    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantCity { get; set; }
        public string RestaurantAdress { get; set; }
        public string RestaurantCuisineType { get; set; }
        public string RestaurantWebsite { get; set; }
        public string RestaurantClosingTime { get; set; }
    }
    public class RestaurantController : ApiController
    {
        static List<Restaurant> rest = new List<Restaurant>()
        {
            new Restaurant { Id = 1,RestaurantName="Sparx Bar and Grill",RestaurantAdress="Mellevile",RestaurantCuisineType="Italian",RestaurantWebsite="",RestaurantClosingTime="11:00pm" },
            new Restaurant { Id = 2,RestaurantName="Scaddabush",RestaurantAdress="Toronto",RestaurantCuisineType="Italian",RestaurantClosingTime="11:00pm" },
            new Restaurant { Id = 3,RestaurantName="Mandarin",RestaurantAdress="Weston",RestaurantCuisineType="Chinese", RestaurantClosingTime="11:00pm"},
            new Restaurant { Id = 4,RestaurantName="Patois", RestaurantAdress="794 Dundas Street W Toronto ONM6J 1V1", RestaurantCuisineType="Thai", RestaurantWebsite="http://www.patoistoronto.com",RestaurantClosingTime="10:00pm" },
            new Restaurant { Id = 5,RestaurantName="Lai Wah Heen",RestaurantAdress="108 Chestnut Street 2/F Toronto, ON M5G1R3",RestaurantCuisineType="Chinese", RestaurantWebsite="http://laiwahheen.com",RestaurantClosingTime="9:00pm"},
            new Restaurant { Id = 6,RestaurantName="Josos",RestaurantAdress="202 Davenport Road, Toronto ON, M5R 1J2",RestaurantCuisineType="Mexican", RestaurantWebsite="http://www.josos.com/",RestaurantClosingTime="10:00pm"}
        };

       
        public IEnumerable<Restaurant> Get(string restaurantCuisineType)
        {
            var restaurants = rest.Where(e => e.RestaurantCuisineType == restaurantCuisineType);
            return restaurants;
        }

        public IEnumerable<Restaurant> Get(string restaurantCuisineType, string restaurantCloseTime)
        {
            var restaurants = rest.Where(e => e.RestaurantCuisineType == restaurantCuisineType &&  e.RestaurantClosingTime == restaurantCloseTime);
            return restaurants;
        }

        public IEnumerable<Restaurant> Get(string restaurantCuisineType, string restaurantCloseTime, string restaurantCity)
        {
            var restaurants = rest.Where(e => e.RestaurantCuisineType == restaurantCuisineType && e.RestaurantClosingTime == restaurantCloseTime && e.RestaurantCity == restaurantCity);
            return restaurants;
        }
        //[HttpGet] //for non Get starting methods
        public IEnumerable<Restaurant> GetCity(string restaurantCity) {
            var restaurants = rest.Where(e => e.RestaurantCuisineType == restaurantCity);
            return restaurants;
        }

        public IEnumerable<Restaurant> GetClosingTime(string restaurantCloseTime)
        {
            var restaurants = rest.Where(e => e.RestaurantClosingTime == restaurantCloseTime);
            return restaurants;
        }

        public IEnumerable<Restaurant> GetCuisineType(string restaurantCuisine)
        {
            var restaurants = rest.Where(e => e.RestaurantCuisineType == restaurantCuisine);
            return restaurants;
        }
        // GET api/values
        public IEnumerable<Restaurant> Get()
        {
            return rest;
        }

        // GET api/values/5
        public Restaurant Get(int id)
        {

            //Restaurant restaurant = new Restaurant();
            return rest[id];
           
        }

        // POST api/values
        public void Post([FromBody]Restaurant value)
        {
            Restaurant restaurant = value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Restaurant value)
        {
            
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}