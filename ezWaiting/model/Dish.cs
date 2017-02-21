using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ezWaiting.model
{
    public class Dish : IComparable<Dish>
    {
        public long Id { get;  set; }
        public string Name { get;  set; }
        public double Price { get;  set; }
        public string Description { get;  set; }
        public string Image { get;  set; }
        public Dictionary<String,double> Variations { get;  set; }
        public List<Ingredient> Ingredients { get;  set; }

        public Dish()
        {
            this.Ingredients = new List<Ingredient>();
            this.Variations = new Dictionary<String, double>();
        }

        public Dish(string name)
        {
            this.Name = name;
            this.Ingredients = new List<Ingredient>();
            this.Variations = new Dictionary<String, double>();
        }

        public String GetStringAllergens()
        {
            HashSet<String> allergeni = new HashSet<string>();
            foreach (Ingredient i in Ingredients)
            {
                foreach (String a in i.Allergens)
                    allergeni.Add(a);
            }
            return string.Join("\n", allergeni);
        }

        public int CompareTo(Dish other)
        {
            return this.Name.CompareTo(other.Name);
        }

        internal string GetStringIngredients()
        {
            String s = "";
            foreach (Ingredient a in Ingredients)
                s = s + a + "\n";
            return s;
        }

        internal bool HasAllergens()
        {
            List<String> allergeni = new List<string>();
            foreach (Ingredient i in Ingredients)
            {
                foreach (String a in i.Allergens)
                    allergeni.Add(a);
            }
            return allergeni.Count != 0;
        }
    }
}
