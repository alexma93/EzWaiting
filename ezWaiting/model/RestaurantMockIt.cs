using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ezWaiting.model
{
    //class to simulate the db
    public class RestaurantMockIt
    {
        public Restaurant Restaurant { get; set; }

        public RestaurantMockIt(Restaurant r)
        {
            Restaurant = r;
            this.Restaurant.People = CreatePeople();
            this.Restaurant.Categories = CreateCategories();
            this.Restaurant.Rooms = CreateRooms();
        }

        private List<Category> CreateCategories()
        {
            Ingredient pasta = new Ingredient
            {
                Name = "Pasta",
                Allergens = new List<string> { "Glutine" }
            };

            Ingredient uovo = new Ingredient
            {
                Name = "Uova",
                Allergens = new List<string> { "Uovo" }
            };

            Ingredient formaggio = new Ingredient
            {
                Name = "Formaggio",
                Allergens = new List<string> { "Latte", "Formaggio" }
            };

            Ingredient latte = new Ingredient
            {
                Name = "Latte",
                Allergens = new List<string> { "Latte", "Latticini" }
            };

            Ingredient pesce = new Ingredient
            {
                Name = "Pesce",
                Allergens = new List<string> { "Pesce"}
            };

            Ingredient prosciutto = new Ingredient
            {
                Name = "Prosciutto",
                Allergens = new List<string> { "Prosciutto" }
            };

            Ingredient Guanciale = new Ingredient
            {
                Name = "Guanciale",
                Allergens = new List<string> { "Maiale" }
            };

            Ingredient Pepe = new Ingredient("Pepe");

            Ingredient SugoPomodoro = new Ingredient("Sugo di Pomodoro");

            Ingredient Carne = new Ingredient("Carne");

            Ingredient Funghi = new Ingredient
            {
                Name = "Funghi",
                Allergens = new List<string> { "Funghi" }
            };

            Ingredient riso = new Ingredient("Riso");

            Ingredient patate = new Ingredient("Patate");

            Ingredient parmigiano = new Ingredient
            {
                Name = "Parmigiano Reggiano",
                Allergens = new List<string> { "Formaggio" }
            };

            Ingredient olio = new Ingredient("Olio");

            Ingredient aceto = new Ingredient("Aceto");

            Ingredient insalata = new Ingredient("Insalata Verde");

            Ingredient pomodoro = new Ingredient("Pomodoro");

            Ingredient finocchio = new Ingredient("Finocchio");

            Ingredient pollo = new Ingredient
            {
                Name = "Pollo",
                Allergens = new List<string> { "Pollo" }
            };

            Ingredient pane = new Ingredient
            {
                Name = "Pane",
                Allergens = new List<string> { "Glutine" }
            };

            Ingredient pinoli = new Ingredient
            {
                Name = "Pinoli",
                Allergens = new List<string> { "Pinoli" }
            };

            Ingredient nutella = new Ingredient
            {
                Name = "Nutella",
                Allergens = new List<string> { "Nocciole", "Olio di Palma" }
            };

            Ingredient cremaPasticcera = new Ingredient
            {
                Name = "Crema Pasticcera",
                Allergens = new List<string> { "Uovo", "Latte", "Glutine" }
            };

            Ingredient panDiSpagna = new Ingredient
            {
                Name = "Pan di Spagna",
                Allergens = new List<string> { "Uovo", "Glutine" }
            };

            Ingredient biscotti = new Ingredient
            {
                Name = "Biscotti",
                Allergens = new List<string> { "Glutine" }
            };

            Ingredient pastaFrolla = new Ingredient
            {
                Name = "Pasta Frolla",
                Allergens = new List<string> { "Glutine", "Uova", "Latte" }
            };


            List<Category> categories = new List<Category>();

            Category c1 = new Category {Name= "Antipasti", Id=1 };
            c1.Dishes = new List<Dish>();

            Dish d1 = new Dish {
                Name = "Tortino di patate",
                Price =5,
                Image = "tortinoPatate",
                Ingredients = new List<Ingredient> { uovo, formaggio }
            };
            c1.Dishes.Add(d1);

            Dish d2 = new Dish {
                Name ="Carpaccio di Pesce",
                Price = 15,
                Image = "tonnocapesante",
                Ingredients = new List<Ingredient> { pesce }
            };
            c1.Dishes.Add(d2);

            Dish d3 = new Dish {
                Name = "Antipasto di Montagna",
                Price =10,
                Image = "antipastoMontagna",
                Ingredients = new List<Ingredient> { formaggio, prosciutto }
            };
            c1.Dishes.Add(d3);

            Category c2 = new Category {
                Name = "Primi",
                Id = 2
            };

            c2.Dishes = new List<Dish>();

            Dish d4 = new Dish
            {
                Name = "Bucatini alla carbonara",
                Price = 14,
                Image = "carbonara",
                Ingredients = new List<Ingredient> { pasta, uovo, parmigiano, Guanciale, Pepe }
            };
            d4.Variations.Add("Mezze Maniche", 0);
            d4.Variations.Add("Senza Pepe", 0);
            c2.Dishes.Add(d4);

            Dish d5 = new Dish
            {
                Name = "Bucatini all'amatriciana",
                Price = 10.5,
                Image = "matriciana",
                Ingredients = new List<Ingredient> { pasta, parmigiano, Guanciale, SugoPomodoro }
            };
            d5.Variations.Add("Mezze Maniche", 0);
            d5.Variations.Add("Spaghetti", 0);
            d5.Variations.Add("Con Peperoncino", 0);
            c2.Dishes.Add(d5);

            Dish d6 = new Dish
            {
                Name = "Risotto ai Funghi",
                Price = 17,
                Image = "mushroomrisotto",
                Ingredients = new List<Ingredient> { riso, parmigiano, Funghi, latte }
            };
            d6.Variations.Add("Porcini", 2);
            d6.Variations.Add("Senza Panna", 0);
            d6.Variations.Add("Riso Venere", 0);
            c2.Dishes.Add(d6);

            Dish d61 = new Dish
            {
                Name = "Spaghetti alla gricia",
                Price = 12,
                Image = "gricia",
                Ingredients = new List<Ingredient> { pasta, parmigiano, Guanciale }
            };
            c2.Dishes.Add(d61);

            Dish d62 = new Dish
            {
                Name = "Lasagna",
                Price = 10,
                Image = "lasagne",
                Ingredients = new List<Ingredient> { pasta, latte }
            };
            c2.Dishes.Add(d62);


            Category c3 = new Category
            {
                Name = "Secondi",
                Id = 3
            };
            c3.Dishes = new List<Dish>();

            Dish d7 = new Dish
            {
                Name = "Bistecca ai Ferri",
                Price = 18,
                Image = "steak",
                Ingredients = new List<Ingredient> { Carne }
            };
            d7.Variations.Add("Al Sangue", 0);
            d7.Variations.Add("Ben Cotta", 0);
            c3.Dishes.Add(d7);

            Dish d8 = new Dish
            {
                Name = "Soutè di Cozze",
                Price = 15.5,
                Image = "pepperedmussels",
                Ingredients = new List<Ingredient> { pesce }
            };
            c3.Dishes.Add(d8);

            Dish d9 = new Dish
            {
                Name = "Orata al Forno",
                Price = 25,
                Image = "orataPatata",
                Ingredients = new List<Ingredient> { pesce }
            };
            c3.Dishes.Add(d9);


            Category c4 = new Category
            {
                Name = "Contorni",
                Id = 4
            };
            c4.Dishes = new List<Dish>();

            Dish d10 = new Dish
            {
                Name = "Patate al Forno",
                Price = 5,
                Image = "patateForno",
                Ingredients = new List<Ingredient> { patate }
            };
            c4.Dishes.Add(d10);

            Dish d11 = new Dish
            {
                Name = "Patate Fritte",
                Price = 5,
                Image = "PatataFritta",
                Ingredients = new List<Ingredient> { patate }
            };
            c4.Dishes.Add(d11);

            Dish d12 = new Dish
            {
                Name = "Insalata",
                Price = 7,
                Image = "insalata",
                Ingredients = new List<Ingredient> { insalata, pomodoro, olio, aceto, finocchio, pinoli }
            };
            c4.Dishes.Add(d12);

            Dish d13 = new Dish
            {
                Name = "Caesar Salad",
                Price = 10,
                Image = "caesarSalad",
                Ingredients = new List<Ingredient> { insalata, pomodoro, olio, aceto, pollo, pane, parmigiano }
            };
            c4.Dishes.Add(d13);

            Category c5 = new Category
            {
                Name = "Dolci",
                Id = 5
            };
            c5.Dishes = new List<Dish>();

            Dish d14 = new Dish
            {
                Name = "Torta della Nonna",
                Price = 7,
                Image = "tortaNonna",
                Ingredients = new List<Ingredient> { cremaPasticcera, pinoli, pastaFrolla }
            };
            c5.Dishes.Add(d14);

            Dish d15 = new Dish
            {
                Name = "Rotolo di Nutella",
                Price = 7,
                Image = "rotolo",
                Ingredients = new List<Ingredient> { panDiSpagna, nutella }
            };
            d15.Variations.Add("Caldo", 0);
            c5.Dishes.Add(d15);

            Dish d16 = new Dish
            {
                Name = "Cheesecake",
                Price = 7,
                Image = "cheasecake",
                Ingredients = new List<Ingredient> { formaggio, biscotti }
            };
            c5.Dishes.Add(d16);

            c1.Dishes.Sort();
            c2.Dishes.Sort();
            c3.Dishes.Sort();
            c4.Dishes.Sort();
            c5.Dishes.Sort();
            categories.Add(c1);
            categories.Add(c2);
            categories.Add(c3);
            categories.Add(c4);
            categories.Add(c5);

            return categories;
        }

        private List<Room> CreateRooms()
        {
            List<Room> rooms = new List<Room> {
                this.CreateAGoodRoom(),
                this.CreateABigRoom()
            };
            return rooms;
        }

        private Room CreateAGoodRoom()
        {
            Room r = new Room
            {
                Width = 5,
                Height = 6,
                Id = 1,
                Name = "Salone principale",
                Tables = new List<Table>()
            };
            r.Tables.Add(new Table("9", 4, 1, 1));
            r.Tables.Add(new Table("8", 2, 3, 1));
            r.Tables.Add(new Table("7", 4, 1, 2));
            r.Tables.Add(new Table("6", 4, 2, 0));
            r.Tables.Add(new Table("4", 2, 2, 3));
            r.Tables.Add(new Table("3", 5, 4, 4));
            r.Tables.Add(new Table("1", 5, 2, 5));
            r.Tables.Add(new Table("2", 3, 1, 5));
            r.Tables.Add(new Table("5", 8, 0, 3));
            r.Tables.Add(new Table("10", 4, 4, 2));
            return r;
        }

        private Room CreateABigRoom()
        {
            Room r = new Room
            {
                Width = 8,
                Height = 6,
                Id = 2,
                Name = "Giardino sul retro",
                Tables = new List<Table>()
            };
            r.Tables.Add(new Table("18", 4, 1, 1));
            r.Tables.Add(new Table("19", 2, 3, 1));
            r.Tables.Add(new Table("16", 4, 1, 2));
            r.Tables.Add(new Table("15", 4, 5, 3));
            r.Tables.Add(new Table("13", 5, 4, 4));
            r.Tables.Add(new Table("11", 5, 2, 5));
            r.Tables.Add(new Table("12", 3, 3, 5));
            r.Tables.Add(new Table("17", 4, 7, 2));
            r.Tables.Add(new Table("14", 4, 6, 4));
            r.Tables.Add(new Table("20", 4, 6, 1));
            return r;
        }

        private List<Table> CreateTables(long roomId)
        {
            Table t;
            List<Table> tables = new List<Table>();
            for (long i = roomId*2; i <= 10; i++)
            {
                t = new Table
                {
                    Id = i,
                    Name = i.ToString(),
                    Seats = 4,
                    Coordinates = new Point(i, i)
                };
                if(t.Id % 4 == 0 || t.Id % 5 == 0)
                {
                    t.OccupyTable(new OccupiedTable(t,3));
                    AddCourse(t.Occupants);

                }
                tables.Add(t);
            }
            return tables;
        }

        private void AddCourse(OccupiedTable t)
        {
            Course c = t.AddCourse();
            Order o;
            List<Dish> orderedDishes = new List<Dish>();
            int i = 0;
            foreach(Category cat in Restaurant.Categories)
                foreach(Dish d in cat.Dishes)
                {
                    if (i % 2 == 0)
                        orderedDishes.Add(d);
                    i++;
                }

            for(int j = 0; j < 4; j++)
            {
                o = new Order(orderedDishes[j], j + 1);
                c.Orders.Add(o);
            }
        }

        private Dictionary<String,Person> CreatePeople()
        {
            Dictionary<String, Person> restaurantPeople = new Dictionary<string, Person>();
            Person waiter1, waiter2, admin;
            waiter1 = new Person("Mario", "Rossi", "utente", "password", 0);
            waiter2 = new Person("Dino","Conta","contadino","zucchina",0);
            admin = new Person("Anna", "Pannocchia", "admin", "admin", 1);
            restaurantPeople.Add(waiter1.Nickname, waiter1);
            restaurantPeople.Add(waiter2.Nickname, waiter2);
            restaurantPeople.Add(admin.Nickname, admin);

            return restaurantPeople;

        }
    }
}
