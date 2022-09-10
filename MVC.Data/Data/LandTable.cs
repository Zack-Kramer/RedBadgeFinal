using System;
namespace MVC.Data.Data
{
    public class LandTable : CardBase
    {
        public string Name { get; set; }
        public int Mana { get; set; } = 0;
        public List<User> Users { get; set; } = new List<User>();
    }
}

