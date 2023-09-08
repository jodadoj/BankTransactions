using BankTransactions.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
//take connection string from secrets.json in full
//var connectString = builder.Configuration["DEVCONNECTION:FULL"];

//take connection string from appsettings piece by piece
var conStrBuilder = new NpgsqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("DevConnection"));
conStrBuilder.Host = builder.Configuration["DEVCONNECTION:SERVER"];
conStrBuilder.Database = builder.Configuration["DEVCONNECTION:DATABASE"];
conStrBuilder.Port = Int32.Parse(builder.Configuration["DEVCONNECTION:PORT"]);
conStrBuilder.Username = builder.Configuration["DEVCONNECTION:USERNAME"];
conStrBuilder.Password = builder.Configuration["DEVCONNECTION:PASSWORD"];
var connection = conStrBuilder.ConnectionString;

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI for DbContext
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TransactionDbContext>(options =>
{
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection"));
    //options.UseNpgsql(connectString);
    options.UseNpgsql(connection);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transaction}/{action=Index}/{id?}");

app.Run();
