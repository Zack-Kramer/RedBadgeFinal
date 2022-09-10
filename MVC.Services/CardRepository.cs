using System;
using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Models._CardModels;
using MVC_IndividualAuthentication.Data.Data;

namespace MVC.Services
{
    public class CardRepository : ICardRepository
        // _context ^ only exists there, technically
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCard(CardCreate cardCreate)
        {
            var entity = new CardBase
            {
                Color = cardCreate.Color,
                Effect = cardCreate.Effect,
                Rarity = cardCreate.Rarity
            };
            await _context.CardBases.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCard(int Id)
        {
            var entity = await _context.CardBases.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            _context.CardBases.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<CardDetail> GetCardbyId(int Id)
        {
            var entity = await _context.CardBases.FindAsync(Id);
            if (entity is null)
            {
                return null;
            }
            return new CardDetail
            {
              Color = entity.Color,
              Effect = entity.Effect,
              Id = entity.Id,
              Rarity = entity.Rarity
            };
        }

        public async Task<IEnumerable<CardIndex>> GetCards()
        {
            var cards = await _context.CardBases.Select(c => new CardIndex
            {
                Color = c.Color,
                Id = c.Id
            }).ToListAsync();
            return cards;
        }

        public async Task<bool> UpdateCard(int Id, CardUpdate cardUpdate)
        {
            var entity = await _context.CardBases.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            entity.Color = cardUpdate.Color;
            entity.Effect = cardUpdate.Effect;
            entity.Rarity = cardUpdate.Rarity;
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
    //^^ This is where you implement the interface via the 'bulb' and this is also where the dbcontext finally comes into play
    //context will be used in the services layer
    //5 tabs at a time is a good rule of thumb, one thing at a time
    //Data, then only do the card models, then the card services, then repeat to get the piece by piece and flow into my head.
    //Services is meant to set up for depedency injection

}

