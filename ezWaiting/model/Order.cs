using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    public class Order
    {
        public long Id { get; set; }
        public Dish Dish { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }

        private int quant;
        private string variat;

        public int Quantity
        {
            get { return quant; }
            set
            {
                quant = value;
                if (variat != null)
                    Price = (Dish.Price + Dish.Variations[variat]) * quant;
                else Price = Dish.Price * quant;
            }
        }
        public String Variation
        {
            get { return variat; }
            set
            {
                if (value != null)
                    Price = (Dish.Price + Dish.Variations[value]) * Quantity;
                 variat = value;
            }
        }

        public Order(Dish d,int q)
        {
            this.Dish = d;
            this.Quantity = q;
        }

        public Order() { }

    }
}
