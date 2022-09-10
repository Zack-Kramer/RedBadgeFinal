using System;
using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Models._CreatureModels;
using MVC.Models._LandModels;
using MVC_IndividualAuthentication.Data.Data;

namespace MVC.Services
{
    public class LandRepository : ILandRepository
    {
        private readonly ApplicationDbContext _context;

        public LandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMana(LandCreate landCreate)
        {
            var entity = new LandTable
            {
                Name= landCreate.Name,
                Mana= landCreate.Mana,
                Effect= landCreate.Effect,
                Color= landCreate.Color,
                Rarity= landCreate.Rarity
            };
            await _context.LandTables.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLand(int Id)
        {
            var entity = await _context.LandTables.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            _context.LandTables.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<LandDetail> GetLandDetails(int id)
        {
            var entity = await _context.LandTables.Include(l=>l.Users).SingleOrDefaultAsync(l=>l.Id==id);
            if (entity is null)
            {
                return null;
            }
            return new LandDetail
            {
                Color = entity.Color,
                Effect = entity.Effect,
                Id = entity.Id,
                Mana = entity.Mana,
                Name = entity.Name,
                Rarity = entity.Rarity,
                Users = entity.Users
            };
        }

        public async Task<IEnumerable<LandIndex>> GetLands()
        {
            var entity = await _context.LandTables.Select(c => new LandIndex
            {
                Id = c.Id,
                Name= c.Name,
                Effect = c.Effect,
                Color = c.Color,
                Mana = c.Mana,
                Rarity = c.Rarity
            }).ToListAsync();
            return entity;
        }

        public async Task<bool> UpdateLand(int Id, LandUpdate landUpdate)
        {
            var entity = await _context.LandTables.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            entity.Mana = landUpdate.Mana;
            entity.Color = landUpdate.Color;
            entity.Effect = landUpdate.Effect;
            entity.Rarity = landUpdate.Rarity;
            entity.Mana = landUpdate.Mana;
            entity.Name = landUpdate.Name;
            await _context.SaveChangesAsync();
            return true;
        }
        //Don't be afraid of break points, it simply shows you what the code is doing/flowing
        //Remember, keep your confidence, break it down into smaller parts
        //When I get done with the course, I am going to do another one. A wee bit simpler than what I originally attempted here, but have a solid foundation
        //Give yourself time to relax and think things through, ask myself how I learn
        //stop comparing yourself, everyone has a different experience
        //You're deadass almost there, keep your head up
        //fun-da-mentals
        //I still have those old videos for foreign keys
        //like writing and sports, just put in those reps
        //keep your vision short, solidify your foundation
        //I like to read, so just go to microsoft documentation, blogs, etc.
        //Dragon ball video was a menu to menu for a good reminder
        //Remember this doesn't happen overnight, Terry has been doing this for five-ish years
        //Remember your due diligence, where you're good, and where you're bad.
        // Keep. Your. Cool. Relax. Stick with it, get lost, explore, there is no one path.
        // If it works, no one cares, it's a win.
        // 2It's only stupid if it doesn't work.


    }
}

