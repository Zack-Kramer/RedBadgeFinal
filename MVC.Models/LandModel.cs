using System;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public class LandModel
    {
        [JsonPropertyName("Mana")]
        public int Mana { get; set; }
        [JsonPropertyName("User")]
        public int User { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; }

        [JsonPropertyName("Effect")]
        public string Effect { get; set; }

        [JsonPropertyName("Rarity")]
        public string Rarity { get; set; }


    }
}

