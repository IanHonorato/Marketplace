using Marketplace.Data.Data;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Repository.Repositories;
using Marketplace.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add string connection
var connectionString = builder.Configuration.GetConnectionString("MarketplaceContext");
builder.Services.AddDbContext<MarketplaceContext>(options =>
    options.UseNpgsql(connectionString));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Add Services in your scoped.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IPaymentInfoService, PaymentInfoService>();
builder.Services.AddScoped<IProductReviewService, ProductReviewService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IPaymentInfoRepository, PaymentInfoRepository>();
builder.Services.AddScoped<IProductReviewRepository, ProductReviewRepository>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Marketplace", Version = "v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
