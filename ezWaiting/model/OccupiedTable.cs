using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    // modella informazioni per un tavolo una volta occupato.
    public class OccupiedTable
    {
        public long Id { get; set; }
        public int OccupiedSeats { get; set; }
        public Payment Payment { get; set; }
        public Table Table { get; set; }
        public List<Course> Courses { get; set; }


        public OccupiedTable()
        {
            this.Courses = new List<Course>();
        }


        public OccupiedTable(Table t,int seats)
        {
            this.Courses = new List<Course>();
            this.OccupiedSeats = seats;
            this.Table = t;
        }

        public Course AddCourse()
        {
            Course c = new Course(this.Courses.Count+1);
            this.Courses.Add(c);
            return c;
        }
    }
    
}
