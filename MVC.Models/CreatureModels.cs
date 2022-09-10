using System;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public class CreatureModels 
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; }

        [JsonPropertyName("Effect")]
        public string Effect { get; set; }

        [JsonPropertyName("Cost")]
        public string cost { get; set; }




    }
}

