using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    // classe da utilizzare nel continuo nel progetto.
    public class Payment
    {
        public long Id { get; set; }
        public string Method { get; set; }
        public double PayedPrice { get; set; }
        public double NormalPrice { get; set; }
    }
}
