using System;
using System.Collections.Generic;

namespace SpaceGame
{
    class Person
    {
        public int money = 1000;
        public List<int> Amount = new List<int>();
        public List<string> Inventory = new List<string>();
        public string Name { get; set; }
        public int SellItem(string item, int price)
        {
            return price;
        }
        public string BuyItem(string item, int price)
        {
            return item;
        }
    }

    class Player : Person
    {
        public Player(string name)
        {
            this.Name = name;
        }
        public bool hasCrystal = false;
        public int travel()
        {
            return 2;
        }
    }
}