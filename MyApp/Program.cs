using Microsoft.EntityFrameworkCore;
using MyApp.Data;

// Load environment variables from file
DotNetEnv.Env.Load();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect to local db in dev mode
builder.Services.AddDbContext<MyAppContext>(options => options.UseOracle(
    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"
    ? Environment.GetEnvironmentVariable("PROD_DB")
    : Environment.GetEnvironmentVariable("DEV_DB"))
);


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
