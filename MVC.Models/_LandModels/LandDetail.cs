using System;
using MVC.Data.Data;

namespace MVC.Models._LandModels
{
    public class LandDetail
    {
        public int Id { get; set; }
        public int Mana { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Effect { get; set; }
        public string Rarity { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}

