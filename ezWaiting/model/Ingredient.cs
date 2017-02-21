using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    public class Ingredient
    {
        public string Name { get; set; }
        public List<String> Allergens { get; set; }

        public Ingredient()
        {
            this.Allergens = new List<string>();
        }

        public Ingredient(string n)
        {
            this.Name = n;
            this.Allergens = new List<string>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
