using Library_System.Mapper;
using Library_System.Models;
using Library_System.Repo.Implmentation;
using Library_System.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<My_AppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
);

builder.Services.AddAutoMapper(
    x => x.AddProfile<MappingProfile>()
    );


builder.Services.AddScoped<BookCustomRepo>();
builder.Services.AddScoped<MemberCustomRepo>();
builder.Services.AddScoped<CategoryCustomRepo>();
builder.Services.AddScoped<BorrowingCustomRepo>();


builder.Services.AddScoped<IBook, BookCustomRepo>();
builder.Services.AddScoped<IMember, MemberCustomRepo>();
builder.Services.AddScoped<ICategory, CategoryCustomRepo>();
builder.Services.AddScoped<IBorrowing, BorrowingCustomRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();




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
