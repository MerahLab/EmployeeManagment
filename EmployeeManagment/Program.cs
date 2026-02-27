using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<AppDbContext>(
    options=>options.UseSqlServer(
        builder.Configuration["ConnectionStrings:EmployeeDbConnection"]
        )
    );
builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();


builder.Services.AddMvc();
var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   ////DeveloperExceptionPageOptions options = new DeveloperExceptionPageOptions();
   //// options.SourceCodeLineCount = 1;
    app.UseDeveloperExceptionPage();
}
else
{
    //app.UseStatusCodePagesWithRedirects("/Error/{0 }");
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0 }");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
   );

app.Run();
