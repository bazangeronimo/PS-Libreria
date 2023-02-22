using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PS.Template.AccessData.Commands;
using PS.Template.AccessData.DBContext;
using PS.Template.AccessData.Queries;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Services;
using PS.Template.Aplication.Utils.Authentication;
using Swashbuckle.AspNetCore.Filters;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Ingrese: 'bearer eyJhbGciOiJodHRwOi8vd3d3...'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


var key = "83kZz7QOdv9Sj3SqT1gS0sjTPqmGDqo8XVXzNDLL";
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        RequireExpirationTime = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSingleton<JwtAuthManager>(new JwtAuthManager(key));



builder.Services.AddDbContext<ProyectoSoftwareContext>((DbContextOptionsBuilder options) =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("LeanConnection")));
builder.Services.AddTransient<IfollowCommands, FollowCommans>();
builder.Services.AddTransient<IFollowService, FollowServices>();
builder.Services.AddTransient<IUserCommands, UserCommands>();
builder.Services.AddTransient<IUserService, UserServices>();
builder.Services.AddTransient<IFollowQuery, FollowQueries>();
builder.Services.AddTransient<IUserQuery, UserQueries>();
builder.Services.AddTransient<IAuthService, authServices>();
builder.Services.AddTransient<IFeaturesQueries, FeaturesQueries>();
builder.Services.AddTransient<IFeaturesService, FeaturesService>();
builder.Services.AddTransient<IFeaturesCommands, FeaturesCommands>();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();
app.Run();
