using HttpMethod_WEB.Profiles;
using AutoMapper;
using HttpMethod_BAL.IService;
using HttpMethod_BAL.Service;
using HttpMethod_DAL.IRepository;
using HttpMethod_DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repository and service
builder.Services.AddScoped<IHTTPMethodRepository, HTTPMethodRepository>();
builder.Services.AddScoped<IHTTPMethodService, HTTPMethodService>();


//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  Global AutoMapper

builder.Services.AddAutoMapper(typeof(ProductProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseRouting(); Before .Net 6

app.MapControllers();

// Minimal APIs

// Example GET Endpoint
app.MapGet("/hello", () => "Hello, World!");

// Example POST Endpoint
app.MapPost("/echo", (string message) => Results.Ok(new { Echo = message }));

// Minimal API Endpoint
app.MapGet("/api/products", () =>
{
    var products = new[]
    {
        new { Id = 1, Name = "Product 1" },
        new { Id = 2, Name = "Product 2" }
    };
    return Results.Ok(products);
});

app.Run();
