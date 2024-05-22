using Application.Interface;
using Application2.Interface;
using Infrastucture;
using Infrastucture2;
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
builder.Services.AddDbContext<UserDbContext>(dbContextOptions =>
dbContextOptions.UseSqlServer(
        builder.
        Configuration.GetConnectionString("ConString"),
        builder => builder.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName)));


//DB Context dependency injection
builder.Services
    .AddScoped<IUserDbContext>(
    provider => provider.GetRequiredService<UserDbContext>()
    );

//dependency of first context
//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


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
