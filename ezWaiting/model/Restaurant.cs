using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    public class Restaurant
    {
        public long id;
        public string name;
        public string address;
        public string currency;
        public List<Room> Rooms { get; set; }
        public List<Category> Categories { get; set; }
        public Dictionary<String, Person> People { get; set; }

        private static Restaurant instance;

        public static Restaurant Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Restaurant();
                    RestaurantMockIt m = new RestaurantMockIt(instance); // change it to work in production
                }
                return instance;
            }
        }

    }
}
