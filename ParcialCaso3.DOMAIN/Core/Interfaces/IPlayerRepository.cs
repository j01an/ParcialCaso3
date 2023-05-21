using ParcialCaso3.DOMAIN.Core.Entities;

namespace ParcialCaso3.DOMAIN.Core.Interfaces
{
    public interface IPlayerRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Player>> GetAll();
        Task<Player> GetById(int id);
        Task<bool> Insert(Player player);
        Task<bool> Update(Player player);
    }
}