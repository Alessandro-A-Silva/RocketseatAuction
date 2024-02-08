using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contratos
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
