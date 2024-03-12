using FIAP.Core.Data;
using FIAP.Core.Entities;
using FIAP.Core.Repositories;
using FIAP.Producer.Filters;
using FIAP.Producer.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => { o.SchemaFilter<SwaggerExcludeFilter>(); });
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
builder.Services.AddScoped<IRepository<Item>, Repository<Item>>();
builder.Services.AddScoped<IRepository<Pedido>, Repository<Pedido>>();
builder.Services.AddScoped<IRepository<Produto>, Repository<Produto>>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
