using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contratos;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAcess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly RocketseatAuctionDbContext _dbContext;
        public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;
            return _dbContext.Auctions.Include(x => x.Items).FirstOrDefault();
        }
    }
}
