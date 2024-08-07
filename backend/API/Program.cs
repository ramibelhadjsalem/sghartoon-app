using API.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers();


builder.Services.AddSwaggerConfiguration();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.OAuthClientId("930828301160-44h71q2fgdtieid626j9irqlg131ng9u.apps.googleusercontent.com");
        c.OAuthClientSecret("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");
        c.OAuth2RedirectUrl("https://localhost:7110/api/Auth/external-login-callback");
        c.OAuthScopes("openid profile email");
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

