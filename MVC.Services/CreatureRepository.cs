using System;
using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Models._CardModels;
using MVC.Models._CreatureModels;
using MVC_IndividualAuthentication.Data.Data;

namespace MVC.Services
{
    public class CreatureRepository : ICreatureRepository
    {
        private readonly ApplicationDbContext _context;

        public CreatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCreature(CreatureCreate creatureCreate)
        {
            var entity = new Creature
            {
                Name = creatureCreate.Name,
                Color = creatureCreate.Color,
                Effect = creatureCreate.Effect,
                Cost = creatureCreate.Cost
            };
            await _context.Creatures.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCreature(int Id)
        {
            var entity = await _context.Creatures.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            _context.Creatures.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CreatureIndex>> GetCreatures()
        {
            var creature = await _context.Creatures.Select(c => new CreatureIndex
            {
                Color = c.Color,
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
            return creature;
        }

        public async Task<CreatureDetail> GetCreaturebyId(int Id)
        {
            var entity = await _context.Creatures.FindAsync(_context);
            if (entity is null)
            {
                return null;
            }
            return new CreatureDetail
            {
                Id = entity.Id,
                Cost = entity.Cost,
                Effect = entity.Effect,
                Name = entity.Name
                //id, cost, effect, name
            };
        }

        public async Task<bool> UpdateCreature(int Id, CreatureUpdate creatureUpdate)
        {
            var entity = await _context.Creatures.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            entity.Cost = creatureUpdate.Cost;
            entity.Effect = creatureUpdate.Effect;
            entity.Id = creatureUpdate.Id;
            entity.Name = creatureUpdate.Name;
            await _context.SaveChangesAsync();
            return true;
            //the only time you actually update the database is when you make changes to the datalayer, as you are changing what it takes to make the table
            //Like setting the table metaphor
        }
    }
}

