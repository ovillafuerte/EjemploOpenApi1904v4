using EjemploOpenApi1904v4.Generic.Domain.Model.Entities;
using EjemploOpenApi1904v4.Generic.Interfaces.REST.Resources;
using EjemploOpenApi1904v4.Generic.Interfaces.REST.Assemblers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.MapGet("/greetings", (string? firstName, string? lastName) =>
    {
        var developer = !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName)
            ? new Developer(firstName, lastName)
            : null;
        var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
        return Results.Ok(response);
    })
    .WithName("GetGreeting")
    .WithOpenApi();
    
// <summary>
// /// Defines the POST endpoint for creating a greeting.
// /// </summary>
// /// <param name="request">The GreetDeveloperRequest containing first and last names.</param>
// /// <returns>An IActionResult containing a GreetDeveloperResponse with a 201 Created status.</returns>
app.MapPost("/greetings", (GreetDeveloperRequest request) =>
    {
        var developer = DeveloperAssembler.ToEntityFromRequest(request);
        var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
        return Results.Created("/greetings", response);
    })
    .WithName("CreateGreeting")
    .WithOpenApi();

app.Run();