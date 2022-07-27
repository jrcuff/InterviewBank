using InterviewBank;
using InterviewBank.Application;
using InterviewBank.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
inMemorySqlite.Open();

builder.Services.AddDbContext<BankDbContext>(optionsBuilder => optionsBuilder.UseSqlite(inMemorySqlite));
builder.Services.AddScoped<RetrieveAccountUseCase>();
builder.Services.AddScoped<CreditAccountUseCase>();
builder.Services.AddScoped<DebitAccountUseCase>();
builder.Services.AddScoped<TransferAccountUseCase>();

var app = builder.Build();

app.SeedData();

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
