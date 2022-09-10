using System;
using MVC.Data.Data;

namespace MVC.Models._LandModels
{
    public class LandIndex
    {
        public int Id { get; set; } = 0;
        public int Mana { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Effect { get; set; }
        public string Rarity { get; set; }
        // you wouldn't put a list here because it could be massive
    }
}

