using System;
using MVC.Data.Data;

namespace MVC.Models._UserModels
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public List<CardTable> Cards { get; set; } = new List<CardTable>();
    }
}

