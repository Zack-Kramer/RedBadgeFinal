using System;
namespace MVC.Data.Data
{
    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Effect { get; set; }
        public int Cost { get; set; }
        public List<CardTable> Cards { get; set; } = new List<CardTable>();
    }
    //This is the next option for crud
    //Then go to card table
    //Then Land Table
    //Then when all things that have foreignkeys are left
    //data
    //models w/out fk
    //services
    //implementation
    //run it through my head, I wrote it down after all
    //Nullable errors are typically data layer related, like putting the ? in front of name etc.

}

