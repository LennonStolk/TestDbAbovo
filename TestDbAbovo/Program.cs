using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TestDbAbovo;
using TestDbAbovo.Models;

var builder = WebApplication.CreateBuilder(args);

// Verbind met de MSSQL database
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestDbAbovo;Trusted_Connection=True;"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "Test database MSSQL Abovo",
         Description = "Zoek het uit",
         Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

app.UseHttpsRedirection();



// GET methods
app.MapGet("/medewerkers", async (DatabaseContext db) => await db.Medewerkers.ToListAsync());
app.MapGet("/afdelingen", async (DatabaseContext db) => await db.Afdelingen.ToListAsync());
app.MapGet("/klanten", async (DatabaseContext db) => await db.Klanten.ToListAsync());
app.MapGet("/projecten", async (DatabaseContext db) => await db.Projecten.ToListAsync());
app.MapGet("/medewerker/{id}", async (DatabaseContext db, int id) => await db.Medewerkers.FindAsync(id));
app.MapGet("/afdeling/{id}", async (DatabaseContext db, int id) => await db.Afdelingen.FindAsync(id));
app.MapGet("/klant/{id}", async (DatabaseContext db, int id) => await db.Klanten.FindAsync(id));
app.MapGet("/project/{id}", async (DatabaseContext db, int id) => await db.Projecten.FindAsync(id));



// POST methods
app.MapPost("/medewerkers", async (DatabaseContext db, Medewerker medewerker) =>
{
    await db.Medewerkers.AddAsync(medewerker);
    await db.SaveChangesAsync();
    return Results.Created($"/medewerker/{medewerker.Id}", medewerker);
});
app.MapPost("/afdelingen", async (DatabaseContext db, Afdeling afdeling) =>
{
    await db.Afdelingen.AddAsync(afdeling);
    await db.SaveChangesAsync();
    return Results.Created($"/afdeling/{afdeling.Id}", afdeling);
});
app.MapPost("/klanten", async (DatabaseContext db, Klant klant) =>
{
    await db.Klanten.AddAsync(klant);
    await db.SaveChangesAsync();
    return Results.Created($"/klant/{klant.Id}", klant);
});
app.MapPost("/projecten", async (DatabaseContext db, Project project) =>
{
    await db.Projecten.AddAsync(project);
    await db.SaveChangesAsync();
    return Results.Created($"/project/{project.Id}", project);
});



// PUT methods
app.MapPut("/medewerker/{id}", async (DatabaseContext db, Medewerker updatemedewerker, int id) =>
{
    var medewerker = await db.Medewerkers.FindAsync(id);
    if (medewerker is null) return Results.NotFound();
    medewerker.Afdeling = updatemedewerker.Afdeling;
    medewerker.Functie = updatemedewerker.Functie;
    medewerker.Geslacht = updatemedewerker.Geslacht;
    medewerker.Leeftijd = updatemedewerker.Leeftijd;
    medewerker.Salaris = updatemedewerker.Salaris;
    medewerker.Naam = updatemedewerker.Naam;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapPut("/afdeling/{id}", async (DatabaseContext db, Afdeling updateafdeling, int id) =>
{
    var afdeling = await db.Afdelingen.FindAsync(id);
    if (afdeling is null) return Results.NotFound();
    afdeling.Adres = updateafdeling.Adres;
    afdeling.Naam = updateafdeling.Naam;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapPut("/klant/{id}", async (DatabaseContext db, Klant updateklant, int id) =>
{
    var klant = await db.Klanten.FindAsync(id);
    if (klant is null) return Results.NotFound();
    klant.Adres = updateklant.Adres;
    klant.Email = updateklant.Email;
    klant.Naam = updateklant.Naam;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapPut("/project/{id}", async (DatabaseContext db, Project updateproject, int id) =>
{
    var project = await db.Projecten.FindAsync(id);
    if (project is null) return Results.NotFound();
    project.Afdelingen = updateproject.Afdelingen;
    project.BeginDatum = updateproject.BeginDatum;
    project.Budget = updateproject.Budget;
    project.EindDatum = updateproject.EindDatum;
    project.IsKlaar = updateproject.IsKlaar;
    project.Klant = updateproject.Klant;
    project.Medewerkers = updateproject.Medewerkers;
    project.Naam = updateproject.Naam;
    await db.SaveChangesAsync();
    return Results.NoContent();
});



// DELETE methods
app.MapDelete("/medewerker/{id}", async (DatabaseContext db, int id) =>
{
   var medewerker = await db.Medewerkers.FindAsync(id);
   if (medewerker is null)
   {
      return Results.NotFound();
   }
   db.Medewerkers.Remove(medewerker);
   await db.SaveChangesAsync();
   return Results.Ok();
});
app.MapDelete("/afdeling/{id}", async (DatabaseContext db, int id) =>
{
   var afdeling = await db.Afdelingen.FindAsync(id);
   if (afdeling is null)
   {
      return Results.NotFound();
   }
   db.Afdelingen.Remove(afdeling);
   await db.SaveChangesAsync();
   return Results.Ok();
});
app.MapDelete("/klant/{id}", async (DatabaseContext db, int id) =>
{
   var klant = await db.Klanten.FindAsync(id);
   if (klant is null)
   {
      return Results.NotFound();
   }
   db.Klanten.Remove(klant);
   await db.SaveChangesAsync();
   return Results.Ok();
});
app.MapDelete("/project/{id}", async (DatabaseContext db, int id) =>
{
   var project = await db.Projecten.FindAsync(id);
   if (project is null)
   {
      return Results.NotFound();
   }
   db.Projecten.Remove(project);
   await db.SaveChangesAsync();
   return Results.Ok();
});



// Andere methods
app.MapPost("/seed", async (DatabaseContext db) =>
{
    // Verwijder alle bestaande date
    db.Medewerkers.RemoveRange(db.Medewerkers);
    db.Afdelingen.RemoveRange(db.Afdelingen);
    db.Klanten.RemoveRange(db.Klanten);
    db.Projecten.RemoveRange(db.Projecten);

    // Verkrijg random data uit de RandomDataGenerator
    var randomDataGenerator = new RandomDataGenerator();
    var medewerkers = randomDataGenerator.GetRandomMedewerkers(50);
    var afdelingen = randomDataGenerator.GetRandomAfdelingen(5);
    var klanten = randomDataGenerator.GetRandomKlanten(10);
    var projecten = randomDataGenerator.GetRandomProjecten(15);

    // Voeg de random data toe
    await db.Medewerkers.AddRangeAsync(medewerkers);
    await db.Afdelingen.AddRangeAsync(afdelingen);
    await db.Klanten.AddRangeAsync(klanten);;
    await db.Projecten.AddRangeAsync(projecten);

    // Ja deze snap je wel
    await db.SaveChangesAsync();
    return Results.Ok();
});


// Ja deze is ook wel handig
app.Run();