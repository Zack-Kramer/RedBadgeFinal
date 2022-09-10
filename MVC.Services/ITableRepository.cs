using System;
using MVC.Models._CardModels;
using MVC.Models._TableModels;
using MVC.Models._UserModels;

namespace MVC.Services
{
    public interface ITableRepository
    {
        Task<bool> AddTable(TableCreate tableCreate);
        Task<IEnumerable<TableIndex>> GetTable();
        Task<TableDetail> GetTablebyId(int Id);
        Task<bool> UpdateTable(int Id, TableUpdate tableUpdate);
        Task<bool> DeleteTable(int Id);
    }
}

