using System;
using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Models._CardModels;
using MVC.Models._LandModels;
using MVC.Models._TableModels;
using MVC.Models._UserModels;
using MVC.Services;
using MVC_IndividualAuthentication.Data.Data;

namespace MVC.Services
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDbContext _context;
        public TableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTable(TableCreate tableCreate)
        {
                var entity = new CardTable
                {
                    CreatureId = tableCreate.CreatureId,
                };
                await _context.CardTables.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<bool> DeleteTable(int Id)
        {
                var entity = await _context.CardTables.FindAsync(Id);
                if (entity is null)
                {
                    return false;
                }
                _context.CardTables.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<IEnumerable<TableIndex>> GetTable()
        {
            var tables = await _context.CardTables.Include(s=>s.Creature).Select(c => new TableIndex
                {
                    Creature = c.Creature,
                    Id = c.Id,
                    CreatureId = c.CreatureId
                }).ToListAsync();
                return tables;
        }

        public async Task<TableDetail> GetTablebyId(int Id)
        {
                    var entity = await _context.CardTables.FindAsync(Id);
                    if (entity is null)
                    {
                        return null;
                    }
                    return new TableDetail
                    {
                        CreatureId = entity.CreatureId,
                        Creature = entity.Creature,
                        Id = entity.Id
                    };
        }

        public async Task<bool> UpdateTable(int Id, TableUpdate tableUpdate)
        {
            var entity = await _context.CardTables.FindAsync(Id);
                if (entity is null)
                {
                    return false;
                }
                entity.Id = tableUpdate.Id;
                entity.CreatureId = tableUpdate.CreatureId;
                entity.Creature = tableUpdate.Creature;
                await _context.SaveChangesAsync();
                return true;
        }
    }
}


// private readonly ApplicationDbContext _context;
//public TableRepository(ApplicationDbContext context)
//{
//    _context = context;
//}

//public async Task<bool> AddTable(TableCreate tableCreate)
//{
//    var entity = new CardTable
//    {
//        Id = tableCreate.Id,
//        CreatureId = tableCreate.CreatureId,
//        Creature = tableCreate.Creature
//    };
//    await _context.CardTables.AddAsync(entity);
//    await _context.SaveChangesAsync();
//    return true;
//}

//public async Task<bool> DeleteTable(int Id)
//{
//    var entity = await _context.CardTables.FindAsync(Id);
//    if (entity is null)
//    {
//        return false;
//    }
//    _context.CardTables.Remove(entity);
//    await _context.SaveChangesAsync();
//    return true;
//}

//public async Task<IEnumerable<TableIndex>> GetTable()
//{
//    var tables = await _context.CardTables.Select(c => new TableIndex
//    {
//        Creature = c.Creature,
//        Id = c.Id,
//        CreatureId = c.CreatureId
//    }).ToListAsync();
//    return tables;
//}

//public async Task<TableDetail> GetTablebyId(int Id)
//{
//    {
//        var entity = await _context.CardTables.FindAsync(Id);
//        if (entity is null)
//        {
//            return null;
//        }
//        return new TableDetail
//        {
//            CreatureId = entity.CreatureId,
//            Creature = entity.Creature,
//            Id = entity.Id
//        };
//    }

//}

//public async Task<TableDetail> GetTableDetails(int id)
//{
//    var entity = await _context.CardTables.Include(l => l.Creature).SingleOrDefaultAsync(l => l.Id == id);
//    if (entity is null)
//    {
//        return null;
//    }
//    return new TableDetail
//    {
//        Creature = entity.Creature,
//        Id = entity.Id,
//        CreatureId = entity.CreatureId,
//    };
//}

//public async Task<IEnumerable<TableIndex>> GetTables()
//{
//    var entity = await _context.CardTables.Select(c => new TableIndex
//    {
//        Id = c.Id,
//        Creature = c.Creature,
//        CreatureId = c.CreatureId
//    }).ToListAsync();
//    return entity;
//}

//public async Task<bool> UpdateTable(int Id, TableUpdate tableUpdate)
//{
//    var entity = await _context.CardTables.FindAsync(Id);
//    if (entity is null)
//    {
//        return false;
//    }
//    entity.Id = tableUpdate.Id;
//    entity.CreatureId = tableUpdate.CreatureId;
//    entity.Creature = tableUpdate.Creature;
//    await _context.SaveChangesAsync();
//    return true;
//}

