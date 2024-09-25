using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// na-Récupérer la clé secrète depuis appsettings.json
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
        ValidateIssuer = true, // na-Valider l'émetteur du token
        ValidateAudience = true, // na-Valider le public du token
        ValidateLifetime = true, // na-Valider la durée de vie du token
        ValidateIssuerSigningKey = true, // na-Valider la clé de signature
        ValidIssuer = builder.Configuration["Jwt:Issuer"], // na-Émetteur défini dans appsettings.json
        ValidAudience = builder.Configuration["Jwt:Audience"], // na-Public défini dans appsettings.json
        IssuerSigningKey = new SymmetricSecurityKey(key) // na-Utiliser la clé secrète pour signer les tokens
    };
});

builder.Services.AddAuthorization(); // Ajouter le service d'autorisation

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication(); // Activer l'authentification JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
