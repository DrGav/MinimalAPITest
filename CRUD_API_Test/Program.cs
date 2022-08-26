using CRUD_API_Test.DAL;
using CRUD_API_Test.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DiaryDbContext>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/diaryentries", async (DiaryDbContext db) => await db.DiaryEntry.ToListAsync());

app.MapPost("/diaryentries", async (DiaryDbContext db, DiaryEntry diary) =>
{
    await db.DiaryEntry.AddAsync(diary);
    await db.SaveChangesAsync();
    return Results.Created($"/diaryentries/{diary.Id}", diary);
});

app.MapGet("/diaryentry/{id}", async (DiaryDbContext db, int id) => await db.DiaryEntry.FindAsync(id));

app.MapPut("/diaryentry/{id}", async (DiaryDbContext db, DiaryEntry updatediary, int id) =>
{
    var diary = await db.DiaryEntry.FindAsync(id);
    if (diary is null) return Results.NotFound();
    diary.Text = updatediary.Text;
    diary.Start = updatediary.Start;
    diary.End = updatediary.End;
    diary.AppointmentOwnerId = updatediary.AppointmentOwnerId;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

