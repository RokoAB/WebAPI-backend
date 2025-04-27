using test.Logic;
using test.Repositories;
using test.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IShoeShopRepository, ShoeShopSqlRepository>();
builder.Services.AddSingleton<IShoeShopLogic, ShoeShopLogic>();

//builder.Services.Configure<DBConfiguration>(builder)

builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("Database"));


builder.Services.AddCors(p => p.AddPolicy("cors_policy_allow_all", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors_policy_allow_all");

app.UseAuthorization();

app.MapControllers();

app.Run();


