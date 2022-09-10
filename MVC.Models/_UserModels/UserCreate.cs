using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models._UserModels
{
    public class UserCreate
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
    }
}

