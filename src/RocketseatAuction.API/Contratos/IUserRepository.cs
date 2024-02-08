using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contratos
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        public User GetUserByEmail(string email);
    }
}
