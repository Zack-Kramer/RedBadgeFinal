using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Data.Data;

namespace MVC.Models._TableModels
{
    public class TableCreate
    {
        public int Id { get; set; }
        //public Creature Creature { get; set; }
        //We don't need this^ because we're making a table. So all we need is just the ID that REPRESENTS the creature that's already been made/ assigned with the idea '3' for example. SQL will then search to find the creature with object of '3'. 
        public int CreatureId { get; set; }

        [ValidateNever]
        public List<SelectListItem> CreatureSelectionList { get; set; } = new List<SelectListItem>();
    }
}

