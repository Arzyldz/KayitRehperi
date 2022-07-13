
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KayitRehperi.API.Filters;
using KayitRehperi.API.Middlewares;
using KayitRehperi.API.Modules;
using KayitRehperi.Core.Models;
using KayitRehperi.Core.Repositories;
using KayitRehperi.Core.Services;
using KayitRehperi.Core.UnitOfWorks;
using KayitRehperi.EmailSenderWorkerService.BackgroundServices;
using KayitRehperi.Repository;
using KayitRehperi.Repository.Repositories;
using KayitRehperi.Repository.UnitOfWorks;
using KayitRehperi.Service.Mapping;
using KayitRehperi.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<,>), typeof(Service<,>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Services.AddAutoMapper(typeof(MapProfile));
//builder.Services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));
//builder.Services.AddHostedService<EmailSenderWorker>();

builder.Services.AddDbContext<AppIdentityDbContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("pSqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppIdentityDbContext)).GetName().Name);
    });
});

builder.Services.AddIdentity<AppUser, AppRole>(Opt =>
{
    Opt.User.RequireUniqueEmail = true;
    Opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();