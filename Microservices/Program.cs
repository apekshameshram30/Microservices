using Application.Interface;
using Infrastucture;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//automapper injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
dbContextOptions.UseSqlServer(
        builder.
        Configuration.GetConnectionString("ConStr"),
        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


//DB Context dependency injection
builder.Services
    .AddTransient<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>()
    );

//Mediator 
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddHttpClient();


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
