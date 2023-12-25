using Aps.Services;
using Aps.Services.IServices;
using Aps.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICopounService, CopounServcies>();

var app = builder.Build();
//SD.CopounAPIBase = builder.Configuration["ServiceUrls:api"];
SD.CouponAPIBase = builder.Configuration["ServiceUrls:api"]!;
builder.Services.AddScoped<IBaseServices, BaseServices>();
builder.Services.AddScoped<ICopounService, CopounServcies>();
//builder.Services.AddScoped<IBaseServices, BaseServices>();
//builder.Services.AddScoped<ICopounService, CopounServcies>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
