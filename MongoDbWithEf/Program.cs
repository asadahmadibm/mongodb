using Microsoft.AspNetCore.Mvc;
using MongoDbWithEf.Data;
using MongoDbWithEf.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/GetAllArticle", (IArticleRepository Repository) =>
{
    return Repository.Get();


})
.WithOpenApi();

app.MapPost("/AddArticle", ([FromBody] Article article , IArticleRepository Repository) =>
{
    return Repository.Post(article);


})
.WithOpenApi();

app.MapDelete("/DeleteArticle", (string id, IArticleRepository Repository) =>
{
    return Repository.Delete(id);


})
.WithOpenApi();

app.MapPut("/AddArticle", ( string Id,[FromBody] Article article, IArticleRepository Repository) =>
{
    return Repository.Put(Id,article);


})
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
