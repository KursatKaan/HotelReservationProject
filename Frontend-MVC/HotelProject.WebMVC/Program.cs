using HotelProject.WebUI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Http Client
builder.Services.AddHttpClient<OurServiceApiService>("OurServiceApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<RoomApiService>("RoomApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<StaffApiService>("StaffApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<SubscribeApiService>("SubscribeApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<TestimonialApiService>("TestimonialApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();