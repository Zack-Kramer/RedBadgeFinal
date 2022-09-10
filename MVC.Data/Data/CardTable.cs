using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Data
{
    public class CardTable : CardBase
    {
        //public int Id { get; set; }
        [ForeignKey(nameof(CreatureId))]
        public Creature? Creature { get; set; }
        public int CreatureId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int UserId { get; set; }


        // The only thing for this would be that a card table can't exist without a creature
        // For SQL we always start at 1, so it would blow up
        //A creature HAS to exist
    }
}

