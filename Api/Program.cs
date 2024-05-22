using Final_Api_Project.BL;
using Final_Api_Project.DAL;
using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string AllowAllCorsPolicy = "AllowAll";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddBLServices(); // add managers
builder.Services.AddDALServices(builder.Configuration); // add context, repos, unit of work

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllCorsPolicy, b =>
    {
        b.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
    });
});


#region Identity

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<E_CommerceContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    // Configure used authentication 
    options.DefaultAuthenticateScheme = "MyDefault";
    options.DefaultChallengeScheme = "MyDefault"; // return 401 if not authenticated, 403 if authenticated but not authorized
})
// Define the authentication scheme
    .AddJwtBearer("MyDefault", options =>
    {
        var keyFromConfig = builder.Configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });

#endregion
#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagersOnly", b =>
        b
        .RequireClaim("Department", "HR", "Management", "string")
        .RequireClaim(ClaimTypes.NameIdentifier));
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(AllowAllCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
