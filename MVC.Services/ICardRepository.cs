using System;
using MVC.Models._CardModels;

namespace MVC.Services
{
    public interface ICardRepository
    {


        //This is the *contract*
        //ie extending the lifetime
        //future needs are apended here
        //Boss needs something else to work, it goes here so we dont have to rebuild anything.
        //Think of interfaces as lego's.

        Task<bool> AddCard(CardCreate cardCreate);
        Task<IEnumerable<CardIndex>> GetCards();
        Task<CardDetail> GetCardbyId(int Id);
        Task<bool> UpdateCard(int Id, CardUpdate cardUpdate);
        Task<bool> DeleteCard(int Id);
        

        //Bool would be ideal, or preferable because it tells us if it works, or it doesn't.

    }
}

