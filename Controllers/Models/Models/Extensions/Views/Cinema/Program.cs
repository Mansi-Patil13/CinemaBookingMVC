var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Route configuration pointing to Cinema controller[cite: 1]
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cinema}/{action=Index}/{id?}");

app.Run();
