using System;
using System.Collections.Generic;

namespace SpaceGame
{
    class Person
    {
        private int money = 0;
        public List<string> Inventory { get; set; }
        public string Name { get; set; }
        public int SellItem(string item, int price)
        {
            return price;
        }
        public string BuyItem(string item, int price)
        {
            return item;
        }
        public string TradeItem(string itemWanted, string itemToTrade)
        {
            return itemWanted;
        }
        public void Speak(string text, Display userInterface)
        {
            userInterface.Write(text);
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

    class EndGameBoss: Person
    {
        public bool isAppeased = false;
        public bool finalCheck()
        {
            return false;
        }
        public bool crystalCheck()
        {
            return false;
        }
    }
}