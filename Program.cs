using dotnet_seven_api.Data;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ItemRepository>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var items = app.MapGroup("items");
items.MapGet("/", ([FromServices] ItemRepository items) =>
{
    return items.GetAll();
});
items.MapGet("/{id}", ([FromServices] ItemRepository items, int id) =>
{
    return items.GetById(id);
});
items.MapPost("/", ([FromServices] ItemRepository items, Item item) =>
{
    if (items.GetById(item.Id) == null)
    {
        items.Add(item);
        return Results.Created($"/items/{item.Id}", item);
    }
    return Results.BadRequest();
});
items.MapPut("/", ([FromServices] ItemRepository items,int id, Item item) =>
{
    var item_details=items.GetById(id);
    if (item_details == null)
        return Results.BadRequest();
    items.Update(item);
    return Results.NoContent();
});
items.MapDelete("/{id}", ([FromServices] ItemRepository items, int id) =>
{
    items.Delete(id);
    return Results.Ok();
});
app.UseHttpsRedirection();
app.Run();

