using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Table> Tables { get; set; }

        public Room() { }
        public Room(string name)
        {
            this.Name = name;
            Tables = new List<Table>();
        }

        public Room(string name, int height, int width) : this(name)
        {
            this.Height = height;
            this.Width = width;
        }

        public void addTable(Table t)
        {
            Tables.Add(t);
        }

        public Table getTableFromCoordinates(int x,int y)
        {
            foreach (Table t in Tables)
                if (t.Coordinates.X == x && t.Coordinates.Y == y)
                    return t;
            return null;
        }
    }



}
