using API.Data;
using API.models;
using API.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<DataContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
    }
);

builder.Services.AddIdentity<User, UserRole>(options =>{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddSignInManager<SignInManager<User>>()
.AddRoleManager<RoleManager<UserRole>>();


builder.Services.AddScoped<TokenService>();

var app = builder.Build();


using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{

    var context =services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<UserRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager, roleManager);
    
}
catch (Exception ex)
{
    var Logger = services.GetRequiredService<ILogger<Program>>();
    Logger.LogError(ex, "An error occured during migration");
}

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
