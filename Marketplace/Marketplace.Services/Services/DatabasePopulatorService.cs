using Bogus;
using Bogus.Extensions.Brazil;
using Bogus.Extensions.UnitedStates;
using Marketplace.Entities.Entities;
using Marketplace.Entities.Enums;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using System;
using System.Data;
using System.Net.Http.Headers;

namespace Marketplace.Services.Services
{
    public class DatabasePopulatorService : IDatabasePopulatorService
    {
        public readonly IUserRepository _userRepository;
        public readonly ISellerRepository _sellerRepository;
        public readonly IProductRepository _productRepository;
        public readonly IProductReviewRepository _productReviewRepository;
        public readonly IPaymentInfoRepository _paymentInfoRepository;
        public readonly IOrderRepository _orderRepository;
        public readonly IOrderItemRepository _orderItemRepository;
        private Faker _faker;// = new Faker();
        public DatabasePopulatorService(IUserRepository userRepository, ISellerRepository sellerRepository, IProductRepository productRepository,
            IProductReviewRepository productReviewRepository, IPaymentInfoRepository paymentRepository, IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository)
        {
            _userRepository = userRepository;
            _sellerRepository = sellerRepository;
            _productRepository = productRepository;
            _productReviewRepository = productReviewRepository;
            _paymentInfoRepository = paymentRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task DatabasePopulator() 
        {
            await UserPopulator();
            await SellerPopulator();
            await ProductPopulator();
            await ProductReviewPopulator();
            await PaymentInfoPopulator();
            await OrderPopulator();
            await OrderItemPopulator();
        }

        private async Task UserPopulator()
        {
            for (int i = 0; i < 20; i++)
            {
                _faker = new Faker();
                var user = new User
                {
                    Name = _faker.Person.FullName,
                    Cpf = _faker.Person.Cpf(),
                    Email = _faker.Person.Email,
                    PasswordHash = _faker.Internet.Password(),
                    PasswordSalt = "passwordSalt",
                    Phone = _faker.Phone.PhoneNumber("###########"),
                    Address = _faker.Address.StreetAddress(),
                    City = _faker.Address.City(),
                    State = _faker.Address.State(),
                    Country = _faker.Address.Country(),
                    ZipCode = _faker.Address.ZipCode("#####-###"),
                    IsSeller = _faker.Random.Bool(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await _userRepository.SaveUser(user);
            }
        }

        private async Task SellerPopulator()
        {
            var sellers = _userRepository.GetAllUsersSellers();
            foreach(User user in sellers)
            {
                _faker = new Faker();
                var seller = new Seller
                (
                    user.IDUser,
                    _faker.Company.CompanyName(),
                    _faker.Company.Cnpj(),
                    _faker.Person.Ssn()
                );

                await _sellerRepository.SaveSeller(seller);
            }
        }

        private async Task ProductPopulator()
        {
            var sellers = await _sellerRepository.GetAllSellers();
            if (sellers != null)
            {
                for (int i = 0; i < 100; i++)
                {
                    _faker = new Faker();
                    var product = new Product
                    (
                        _faker.Random.Int(1, sellers.Count),
                        _faker.Commerce.ProductName(),
                        _faker.Commerce.ProductDescription(),
                        _faker.Image.PlaceImgUrl(),
                        decimal.Parse(_faker.Commerce.Price()),
                        _faker.Random.Int(0, 200),
                        DateTime.Now,
                        DateTime.Now
                    );

                    await _productRepository.SaveProduct(product);
                }
            }
        }

        private async Task ProductReviewPopulator()
        {
            for (int i = 0; i < 200; i++)
            {
                _faker = new Faker();
                var productReview = new ProductReview
                (
                    _faker.Random.Int(1, 20),
                    _faker.Random.Int(1, 100),
                    _faker.Random.Int(0, 10),
                    _faker.Lorem.Sentences(),
                    DateTime.Now,
                    DateTime.Now
                );

                await _productReviewRepository.SaveProductReview(productReview);
            }
        }

        private async Task PaymentInfoPopulator()
        {
            for (int i = 1; i <= 20; i++)
            {
                _faker = new Faker();
                var paymentInfo = new PaymentInfo
                (
                    i,
                    _faker.Finance.GetType().Name,
                    _faker.Finance.CreditCardNumber(),
                    _faker.Date.FutureDateOnly(8).ToString(),
                    _faker.Finance.CreditCardCvv()
                );

                await _paymentInfoRepository.SavePaymentInfo(paymentInfo);
            }
        }

        private async Task OrderPopulator()
        {
            _faker = new Faker();
            for (int i = 1; i <= 40; i++)
            {
                var order = new Order
                (
                    _faker.Random.Int(1, 20),
                    _faker.Random.Decimal((decimal)200.00, (decimal)1000.00),
                    DateTime.Now,
                    DateTime.Now,
                    _faker.Random.Enum<Status>(),
                    _faker.Address.StreetAddress(),
                    _faker.Address.City(),
                    _faker.Address.State(),
                    _faker.Address.Country(),
                    _faker.Address.ZipCode("#####-###")
                );

                await _orderRepository.SaveOrder(order);
            }
        }

        private async Task OrderItemPopulator()
        {
            _faker = new Faker();
            for (int i = 1; i <= 500; i++)
            {
                var orderItem = new OrderItem
                (
                    _faker.Random.Int(1, 40),
                    _faker.Random.Int(1, 100),
                    _faker.Random.Int(1, 10),
                    decimal.Parse(_faker.Commerce.Price()) * _faker.Random.Int(1, 10)
                );

                await _orderItemRepository.SaveOrderItem(orderItem);
            }
        }
    }
}