using System;
using MVC.Data.Data;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public class UserModels
    {

        [JsonPropertyName("Id")]
        public string Id { get; set; }


        [JsonPropertyName("PlayerName")]
        public string PlayerName { get; set; }
        
    }
}

