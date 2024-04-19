using Todo_List.Core;
using Todo_List.Infrastructure;
using Todo_List.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with dependency injection
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

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
    pattern: "{controller=Task}/{action=Index}/{id?}");

// Add a specific route for the Create action as a GET request
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "create",
        pattern: "Task/Create",
        defaults: new { controller = "Task", action = "Create" },
        constraints: new { httpMethod = new HttpMethodRouteConstraint("GET") }
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Task}/{action=Index}/{id?}");
});

app.Run();