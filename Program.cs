using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// na-R�cup�rer la cl� secr�te depuis appsettings.json
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]); // Utilise "SalutLesLMSN2024"

// na-Configurer l'authentification JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // na-Valider l'�metteur du token
        ValidateAudience = true, // na-Valider le public du token
        ValidateLifetime = true, // na-Valider la dur�e de vie du token
        ValidateIssuerSigningKey = true, // na-Valider la cl� de signature
        ValidIssuer = builder.Configuration["Jwt:Issuer"], // na-�metteur d�fini dans appsettings.json
        ValidAudience = builder.Configuration["Jwt:Audience"], // na-Public d�fini dans appsettings.json
        IssuerSigningKey = new SymmetricSecurityKey(key) // na-Utiliser la cl� secr�te pour signer les tokens
    };
});

builder.Services.AddAuthorization(); // Ajouter le service d'autorisation

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication(); // Activer l'authentification JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
