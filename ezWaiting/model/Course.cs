using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{

    public class Course
    {
        public long Id { get; set; }
        public int Number { get; set; } // prima,seconda,... portata
        public DateTime Time { get; set; } //non la gestiamo. Utile se si continua il progetto.
        public List<Order> Orders { get; set; }

        public Course()
        {
            this.Orders = new List<Order>();
        }

        public Course(int n)
        {
            this.Orders = new List<Order>();
            this.Number = n;
        }
    }
}
