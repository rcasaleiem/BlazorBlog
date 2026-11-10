using AutoMapper;
using BlazorBlog.Components;
using BlazorBlog.Models.Mappers;
using BlazorBlog.Models.Tables;
using BlazorBlog.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using NLog.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();  
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Host.UseNLog(); 

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleBlog", Version = "v1" });
      
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Logging.AddConsole();

builder.Services.AddDbContext<BlogDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("LocalServer"),
        new MySqlServerVersion(new Version(9, 2, 0)) 
    )
    .EnableDetailedErrors()
    .UseLazyLoadingProxies()
);

builder.Services.AddScoped<FileService>();
builder.Services.AddScoped<CrudHandler>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MappingProfile>();
});



var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();