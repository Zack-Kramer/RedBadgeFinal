using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Data;

namespace MVC.Models
{
    public class CardModels
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; }

        [JsonPropertyName("Effect")]
        public string Effect { get; set; }

        [JsonPropertyName("Rarity")]
        public string Rarity { get; set; }

        

    }
}

