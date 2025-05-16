using AutoMapper;
using GRE.Persistence;
using GRE.Persistence.Implementations.Services.AutoMapper;
using GRE.WebApi.Middleware;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddInfrastructure(config);
string mySqlConnectionStr = (config["ConnectionStrings:Default"]);
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(mySqlConnectionStr));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidateLifetime = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };

//});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfileCongifuration());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseStaticFiles();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
