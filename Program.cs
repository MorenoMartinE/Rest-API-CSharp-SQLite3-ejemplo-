using apiRest.Data;
using apiRest.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSqlite<PersonalContext>("Data Source=apiRest.db");
builder.Services.AddScoped<PersonalService>();



var app = builder.Build();

app.CreateDbIfNotExists();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
