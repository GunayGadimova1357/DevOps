var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient("ApiClient", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["ApiSettings:BaseUrl"];

    if (string.IsNullOrEmpty(baseUrl))
    {
        throw new InvalidOperationException("ApiSettings:BaseUrl is not configured");
    }

    client.BaseAddress = new Uri(baseUrl);
});

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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
