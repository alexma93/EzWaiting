using System;
using System.Collections.Generic;
using System.Text;

namespace ezWaiting.model
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsChef { get; set; }
        public bool IsWaiter { get; set; }
        //ora tutti i camerieri possono gestire tutta la sala.
        public List<OccupiedTable> tables;

        public Person(string name,string surname,string nickname, string password, int role )
        {
            this.Name = name;
            this.Surname = surname;
            this.Nickname = nickname;
            this.Password = password;
            switch (role)
            {
                case 1:
                    this.IsAdmin = true;
                    this.IsChef = false;
                    this.IsWaiter = false;
                    break;
                case 2:
                    this.IsChef = true;
                    this.IsAdmin = false;
                    this.IsWaiter = false;
                    break;
                default:
                    this.IsWaiter = true;
                    this.IsChef = false;
                    this.IsAdmin = false;
                    break;
            }
            this.tables = new List<OccupiedTable>();
        }
        
    }
}
