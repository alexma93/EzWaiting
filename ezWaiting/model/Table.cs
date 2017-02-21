using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ezWaiting.model
{
    public class Table : INotifyPropertyChanged
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public Point Coordinates { get; set; } // le coordinate del tavolo nella sala (X,Y)

        private bool Occ;
        public bool Occupied
        {   get { return Occ; }
            set
            {
                Occ = value;
                Table_OccupiedChanged();
            }
        }

        public OccupiedTable Occupants { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Table()
        {
            this.Occ = false;
            this.PropertyChanged += Table_PropertyChanged;
        }

        public Table(string name, int seats, Point coordinates)
        {
            this.Name = name;
            this.Seats = seats;
            this.Coordinates = coordinates;
        }

        public Table(string name, int seats, int x,int y)
        {
            this.Name = name;
            this.Seats = seats;
            this.Coordinates = new Point(x, y);
            this.Occ = false;
            this.PropertyChanged += Table_PropertyChanged;
        }

        //non fa nulla, ma mi evita che l'evento non venga gestito
        private void Table_PropertyChanged(object sender, PropertyChangedEventArgs e) { }

       
        public void OccupyTable(OccupiedTable o)
        {
            this.Occupants = o;
            this.Occupied = true;
        }

        public void FreeTable()
        {
            this.Occupants = null;
            this.Occupied = false;
        }

        public bool IsFree()
        {
            return !this.Occupied;
        }

        private void Table_OccupiedChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Occupied"));
        }

    }
}
