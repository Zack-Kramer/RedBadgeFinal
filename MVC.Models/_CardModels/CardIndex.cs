using System;
namespace MVC.Models._CardModels
{
    public class CardIndex
    {
        public int Id { get; set; }
        public string Color { get; set; }

        // the model layer is just WHAT THE USER SEES
        // because lets not show everyone the raw code.
        //This is the 'control' or 'draft' section more or less
    }
}

