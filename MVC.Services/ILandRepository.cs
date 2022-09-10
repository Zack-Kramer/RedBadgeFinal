using System;
using MVC.Models._CreatureModels;
using MVC.Models._LandModels;

namespace MVC.Services
{
    public interface ILandRepository
    {
        Task<bool> AddMana(LandCreate landCreate);
        Task<IEnumerable<LandIndex>> GetLands();
        Task<LandDetail> GetLandDetails(int id);
        Task<bool> UpdateLand(int Id, LandUpdate landUpdate);
        Task<bool> DeleteLand(int Id);
    }
}

