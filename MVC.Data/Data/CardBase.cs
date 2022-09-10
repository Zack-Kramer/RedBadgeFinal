using System;
namespace MVC.Data.Data
{
    public class CardBase
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? Effect { get; set; }
        public string? Rarity { get; set; }
    }
}

