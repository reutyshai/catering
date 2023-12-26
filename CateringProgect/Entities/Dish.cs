﻿namespace CateringProgect
{
    public class Dish
    {
        public int id { get; set; }
        public int price { get; set; }
        public string name { get; set; }
        public string sideDish { get; set; }
        public bool isSideDish { get; set; }

        public Dish()
        {
        }

        public Dish(int id,int price, string name, string sideDish) : this(id,price, name, sideDish, false) { }
           
        

        public Dish(int id,int price, string name, string sideDish, bool isSideDish)
        {
            this.id = id;
            this.price = price;
            this.name = name;
            this.sideDish = sideDish;
            this.isSideDish = isSideDish;
        }
    }
}
