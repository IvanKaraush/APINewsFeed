using APINewsFeed.BLL.Configuration;
using APINewsFeed.BLL.DTO.PostDTOs;
using APINewsFeed.BLL.DTO.UserDTOs;
using APINewsFeed.BLL.Interfaces;
using APINewsFeed.BLL.Repository;
using APINewsFeed.BLL.Services;
using APINewsFeed.BLL.Validators.PostValidators;
using APINewsFeed.BLL.Validators.UserValidators;
using APINewsFeed.DAL.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "APINewsFeed",
        Version = "v1",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "APINewsFeed.BLL.xml"));
});

builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHasher, HasherService>();
builder.Services.AddScoped<IImageService, ImageStorageService>();


builder.Services.AddTransient<IValidator<UserRegistrationDTO>, AddUserValidatorDTO>();
builder.Services.AddTransient<IValidator<UpdateUserDTO>, UpdateUserValidatorDTO>();
builder.Services.AddTransient<IValidator<DeleteUserDTO>, DeleteUserValidatorDTO>();
builder.Services.AddTransient<IValidator<GetUserDTO>, GetUserValidatorDTO>();
builder.Services.AddTransient<IValidator<UserAuthorizationDTO>, UserAuthorizationValidatorDTO>();
builder.Services.AddTransient<IValidator<UserRegistrationDTO>, UserRegistrationsValidatorDTO>();
builder.Services.AddTransient<IValidator<GetUsersDTO>, GetUsersValidatorDTO>();
builder.Services.AddTransient<IValidator<CreatePostDTO>, CreatePostDTOValidator>();
builder.Services.AddTransient<IValidator<GetPostByIdDTO>, GetPostByIdDTOValidator>();
builder.Services.AddTransient<IValidator<FilterPostDTO>, FilterPostDTOValidator>();
builder.Services.AddTransient<IValidator<GetPostsByUserIdDTO>, GetPostByUserIdDTOValidator>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
