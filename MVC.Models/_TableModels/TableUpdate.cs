using System;
using MVC.Data.Data;

namespace MVC.Models._TableModels
{
    public class TableUpdate
    {
        public int Id { get; set; }
        public Creature Creature { get; set; }
        public int CreatureId { get; set; }
    }
}

