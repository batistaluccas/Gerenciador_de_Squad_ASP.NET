using API.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

addScope(builder.Services);

void addScope(IServiceCollection services)
{
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


    builder.Services.AddDbContext<EFContext>(options =>
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
        b => b.MigrationsAssembly("API")));

    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddScoped<IPersonRepository, PersonRepository>();

    builder.Services.AddScoped<IUserService, UserService>();

    builder.Services.AddScoped<IPersonService, PersonService>();



}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
