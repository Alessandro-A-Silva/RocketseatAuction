using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Comunication.Requests;
using RocketseatAuction.API.Contratos;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UserCase.Test.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Sucesso(int itemId)
        {
            //ARRANGE - instancia o que precissa
            var request = new Faker<RequestCreateOfferJson>().RuleFor(request => request.Price, f => f.Random.Decimal(1, 100)).Generate();

            var offerRepository = new Mock<IOfferRepository>();
            var loggerUser = new Mock<ILoggedUser>();
            loggerUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggerUser.Object,offerRepository.Object);

            //ACT - executa
            var act = () => useCase.Execute(itemId, request);

            //ASSERT - verifica o resultado
            act.Should().NotThrow();
        }
    }
}
