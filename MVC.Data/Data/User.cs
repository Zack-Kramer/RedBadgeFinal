using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Data
{
    public class User
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public List<CardTable> Cards { get; set; } = new List<CardTable>();
    }
}

//After finishing User, finish the Lands

