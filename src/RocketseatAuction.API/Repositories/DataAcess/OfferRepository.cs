using RocketseatAuction.API.Contratos;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAcess
{
    public class OfferRepository : IOfferRepository
    {   
        private readonly RocketseatAuctionDbContext _context;
        public OfferRepository(RocketseatAuctionDbContext context)
        {
            _context = context;
        }

        public void Add(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }
    }
}
