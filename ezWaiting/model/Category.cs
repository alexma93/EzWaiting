using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    // categoria di piatti di un menu' (antipasti,primi,...)
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Kitchen Kitchen { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
