using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contratos
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
