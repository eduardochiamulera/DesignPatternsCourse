using Api;
using DesignPatterns.src.GOF.Structural.Adapter.Catalog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
	options.ConfigureHttpsDefaults(httpsOptions =>
	{
		// Forçar uso de TLS 1.2 e TLS 1.3
		httpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
	});
});

// Add services to the container.
builder.Services.AddControllers();
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

// Criar a instância do adaptador e registrar as rotas
IHttpServer server = new AspNetCoreAdapter(app);

// Exemplo de registro de rotas
server.Register("GET", "/products/{productId}", async (routeValues) =>
{
	var productIdString = routeValues["productId"]?.ToString();

	var productRepository = new ProductRepositoryMemory();
	var getProduct = new GetProduct(productRepository);

	if (int.TryParse(productIdString, out var productId))
	{
		var product = await getProduct.Execute(productId);

		return product;
	}

	return new { error = "Invalid productId" };
});

server.Register("GET", "/products", async (routeValues) =>
{
	var productRepository = new ProductRepositoryMemory();
	var getProduct = new GetProduct(productRepository);

	if (int.TryParse("1", out var productId))
	{
		var product = await getProduct.Execute(productId);

		return new { product };
	}

	return new { error = "Invalid productId" };
});


// Iniciar o servidor
server.Listen(5000);