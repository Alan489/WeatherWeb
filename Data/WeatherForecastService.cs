namespace Weather2EB.Data
{
 public class WeatherForecastService
 {
  private HttpClient _http;

  public WeatherForecastService(HttpClient http)
  {
   _http = http;
  }

  public async Task<List<timestampedforcast>?> getForecast(string lat, string lng)
  {
   List<timestampedforcast> returner = new List<timestampedforcast>();
   string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lng}&current=temperature_2m,precipitation,rain,showers,snowfall,cloud_cover&hourly=temperature_2m,precipitation_probability,wind_speed_10m&daily=sunrise,sunset&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&timezone=America%2FNew_York&forecast_days=3";
   var ret = await _http.GetFromJsonAsync<WeatherForecast>(url);
   if (ret == null) return null;

   for (int i = 0; i < ret.hourly.time.Count; i++)
   {
    timestampedforcast _temp = new timestampedforcast();
    _temp.time = ret.hourly.time[i];
    _temp.temp = (int) ret.hourly.temperature_2m[i];
    _temp.precip = ret.hourly.precipitation_probability[i];
    _temp.windspeed = (int) ret.hourly.wind_speed_10m[i];
    returner.Add(_temp);
   }

   return returner;

  }

  public async Task<timestampedforcast?> getCurrent(string lat, string lng)
  {
   timestampedforcast returner = new timestampedforcast();
   string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lng}&current=temperature_2m,precipitation,rain,showers,snowfall,cloud_cover&hourly=temperature_2m,precipitation_probability,wind_speed_10m&daily=sunrise,sunset&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&timezone=America%2FNew_York&forecast_days=3";
   var ret = await _http.GetFromJsonAsync<WeatherForecast>(url);
   if (ret == null) return null;

   returner.cloud = ret.current.cloud_cover;
   returner.temp = ret.current.temperature_2m;
   returner.sunstuff = ret.daily;


   return returner;

  }



 }
}
