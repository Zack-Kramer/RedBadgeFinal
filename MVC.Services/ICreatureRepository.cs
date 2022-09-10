using System;
using MVC.Models._CreatureModels;
// Using Creature models here when crud is complete.
namespace MVC.Services
{
    public interface ICreatureRepository
    {
        Task<bool> AddCreature(CreatureCreate creatureCreate);
        Task<IEnumerable<CreatureIndex>> GetCreatures();
        Task<CreatureDetail> GetCreaturebyId(int Id);
        Task<bool> UpdateCreature(int Id, CreatureUpdate creatureUpdate);
        Task<bool> DeleteCreature(int Id);
    }
}

