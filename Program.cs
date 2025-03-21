using WeatherApi.Interface;
using WeatherApi.Repository;
using WeatherApi.Config; // ✅ Config klasörünü ekliyoruz
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// ✅ OpenWeather config'i appsettings.json'dan çekip DI container'a ekliyoruz
builder.Services.Configure<OpenWeatherConfig>(builder.Configuration.GetSection("OpenWeather"));

builder.Services.Configure<CitiesConfig>(builder.Configuration.GetSection("TürkiyeAPI"));


// DI (Dependency Injection) servisleri
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Weather API servisini ve HttpClient'ı ekliyoruz
builder.Services.AddHttpClient<IWeatherService, WeatherRepository>();
builder.Services.AddHttpClient<IForecastService, ForecastRepository>();
builder.Services.AddHttpClient<ICityService ,CitiesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔥 Rotalama middleware'i
app.UseRouting();

app.UseAuthorization();

// 🔥 Controller'ları haritalıyoruz
app.MapControllers();

app.Run();
