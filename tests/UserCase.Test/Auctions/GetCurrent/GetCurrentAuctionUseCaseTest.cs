using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contratos;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UserCase.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Sucesso()
        {
            //ARRANGE - instancia o que precissa
            var entity = new Faker<Auction>().RuleFor(auction => auction.Id, f => f.Random.Number(1,100))
                                             .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                                             .RuleFor(auction => auction.Starts, f => f.Date.Past())
                                             .RuleFor(auction => auction.Ends, f => f.Date.Future())
                                             .RuleFor(auction => auction.Items, (f,auction) => new List<Item>
                                             {
                                                 new Item
                                                 {
                                                     Id = f.Random.Number(1,100),
                                                     Name = f.Commerce.ProductName(),
                                                     Brand = f.Commerce.Department(),
                                                     BasePrice = f.Random.Decimal(50, 734),
                                                     Condition = f.PickRandom<Condition>(),
                                                     AuctionId = auction.Id
                                                 }
                                             }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(entity);

            var useCase = new GetCurrentAuctionUseCase(mock.Object);

            //ACT - executa
            var auction = useCase.Execute();

            //ASSERT - verifica o resultado
            auction.Should().NotBeNull();
            auction!.Id.Should().Be(entity.Id);
            auction.Name.Should().Be(entity.Name);
            auction.Ends.Should().Be(entity.Ends);
            auction.Starts.Should().Be(entity.Starts);
        }
    }
}
