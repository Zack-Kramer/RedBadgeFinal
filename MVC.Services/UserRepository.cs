using System;
using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Models._CardModels;
using MVC.Models._LandModels;
using MVC.Models._UserModels;
using MVC_IndividualAuthentication.Data.Data;
namespace MVC.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(UserCreate userCreate)
        {
            var entity = new User
            {
                PlayerName = userCreate.PlayerName
            };
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteUser(int Id)
        {
            var entity = await _context.Users.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserIndex>> GetUser()
        {
            var users = await _context.Users.Select(c => new UserIndex
            {
                Id = c.Id,
                PlayerName = c.PlayerName
            }).ToListAsync();
            return users;
        }

        public async Task<UserDetail> GetUserbyId(int Id)
        {
            var entity = await _context.Users.FindAsync(Id);
            if (entity is null)
            {
                return null;
            }
            return new UserDetail
            {
                
                Id = entity.Id,
                PlayerName = entity.PlayerName
            };
        }

        public async Task<bool> UpdateUser(int Id, UserUpdate userUpdate)
        {
            var entity = await _context.Users.FindAsync(Id);
            if (entity is null)
            {
                return false;
            }
            entity.PlayerName = userUpdate.PlayerName;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

