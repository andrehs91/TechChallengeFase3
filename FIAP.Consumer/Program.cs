using FIAP.Consumer;
using FIAP.Consumer.Services;
using FIAP.Core.Data;
using FIAP.Core.Entities;
using FIAP.Core.Repositories;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
builder.Services.AddScoped<IRepository<Item>, Repository<Item>>();
builder.Services.AddScoped<IRepository<Pedido>, Repository<Pedido>>();
builder.Services.AddScoped<IRepository<Produto>, Repository<Produto>>();
builder.Services.AddScoped<IConsumerService, ConsumerService>();

var host = builder.Build();
host.Run();
