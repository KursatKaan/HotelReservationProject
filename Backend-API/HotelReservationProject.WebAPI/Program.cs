using Autofac;
using Autofac.Extensions.DependencyInjection;
using HotelProject.Service.DependencyResolvers;
using HotelProject.Service.Mapping;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DependencyResolvers
builder.Services.AddIdentityInjection();
builder.Services.AddDbContextInjection();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(Cb => Cb.RegisterModule(new IoCContainer()));

//Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(2);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HotelApiCors");

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
