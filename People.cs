using System;
using System.Collections.Generic;

namespace SpaceGame
{
    class Person
    {
        public int money = 50;
        public List<string> Inventory  { get; set; }
        public List<int> Amount { get; set; }
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

    class Player: Person
    {
        public bool hasCrystal = false;
        public int travel()
        {
            return 2;
        }
    }
}