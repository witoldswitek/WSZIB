using AutoFixture;
using FluentAssertions;
using Shop.Core.Domain;
using Shop.Core.Repositories;
using System.Linq;
using Xunit;

namespace Shop.Tests.Repositories
{
    public class OrderRepositoryTest
    {
        [Fact]
        public void AddingAnOrderShouldSucceedd()
        {
            //Arrange - przygotowanie
            IOrderRepository orderRepository = new OrderRepository();
            var cart = new Cart();
            cart.AddProduct(new Product("name", "category", 100));
            var order = new Order(new User("mail","pass", Role.User ), cart); 

            //Act - wykonanie
            orderRepository.Add(order);

            //Assert - sprawdzenie
            var expectedOrder = orderRepository.Get(order.Id);
            Assert.Equal(expectedOrder, order);

            var orders = orderRepository.Browse(order.UserId);
            Assert.NotEmpty(orders);
            Assert.Single(orders);
            Assert.Contains(orders, o => o.Id == order.Id);            
        }

        [Fact]
        public void AddingAnOrderShouldSucceeddWithLibs()
        {
            //Arrange - przygotowanie
            IOrderRepository orderRepository = new OrderRepository();
            var fixture = new Fixture();

            var user = fixture.Create<User>();
            var cart = fixture.Create<Cart>();
            var product = fixture.Create<Product>();

            cart.AddProduct(product);

            var order = new Order(user, cart);
            
            //Act - wykonanie
            orderRepository.Add(order);

            //Assert - sprawdzenie
            var expectedOrder = orderRepository.Get(order.Id);
            var orders = orderRepository.Browse(order.UserId);

            expectedOrder.ShouldBeEquivalentTo(order);                        
            orders.Should().NotBeEmpty();
            orders.Should().ContainSingle();
            orders.Should().Contain(o => o.Id == order.Id);
            
        }
    }
}
