using Microsoft.EntityFrameworkCore;
using SchoolProSite.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SchoolContext>(option=> 
            option.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

#region "Registro de Componentes Daos"
builder.Services.AddTransient<SchoolContext>();
#endregion

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
