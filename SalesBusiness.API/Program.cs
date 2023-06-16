using Microsoft.EntityFrameworkCore;
using SalesBusiness.Api.Consumer;
using SalesBusiness.Api.Data;
using SalesBusiness.API.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SalesBusinessContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SalesBusinessDbConnection"));
});

builder.Services.AddMassTransit(x =>
{
	x.AddConsumer<ProductCreatedConsumer>();
	x.UsingRabbitMQ((context, cfg) =>
	{
		cfg.Host(new Uri("rabbitmq://localhost:4001"), h =>
		{
			h.Username("guest");
			h.Password("guest");
		})
		cfg.ReceiveEndpoint("event-listener", e =>
		{
			e.ConfigureConsumer<ProductCreatedConsumer>();
		});
	});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
