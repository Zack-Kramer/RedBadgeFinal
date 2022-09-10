using System;
namespace MVC.Models._CreatureModels
{
    public class CreatureCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Effect { get; set; }
        public int Cost { get; set; }
    }
}

