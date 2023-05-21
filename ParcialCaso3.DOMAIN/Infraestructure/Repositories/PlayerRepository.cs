using Microsoft.EntityFrameworkCore;
using ParcialCaso3.DOMAIN.Core.Entities;
using ParcialCaso3.DOMAIN.Core.Interfaces;
using ParcialCaso3.DOMAIN.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ParcialCaso3.DOMAIN.Infraestructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Parcial202320100651Context _dbContext;

        public PlayerRepository(Parcial202320100651Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(Player player)
        {
            await _dbContext.Player.AddAsync(player);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Player player)
        {
            _dbContext.Player.Update(player);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var player = await _dbContext.Player.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (player == null)
                return false;

            _dbContext.Player.Remove(player);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            var result = await _dbContext.Player.ToListAsync();
            return result;
        }

        public async Task<Player> GetById(int id)
        {
            var result = await _dbContext.Player.Where(X => X.Id == id).FirstOrDefaultAsync();
            return result;
        }

    }
}
