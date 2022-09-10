using System;
using MVC.Models._CardModels;
using MVC.Models._UserModels;

namespace MVC.Services
{
    public interface IUserRepository
    {
        Task<bool> AddUser(UserCreate userCreate);
        Task<IEnumerable<UserIndex>> GetUser();
        Task<UserDetail> GetUserbyId(int Id);
        Task<bool> UpdateUser(int Id, UserUpdate userUpdate);
        Task<bool> DeleteUser(int Id);
    }
}

