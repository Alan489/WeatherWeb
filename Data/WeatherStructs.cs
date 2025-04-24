namespace Weather2EB.Data
{
 public class timestampedforcast
 {
  public DateTime time { get; set; }
  public double temp { get; set; }
  public int precip { get; set; }
  public double windspeed { get; set; }
  public int cloud { get; set; }
 }

 public class UnitsDeclaration
 {
  public string time { get; set; }
  public string interval { get; set; }
  public string temperature_2m { get; set; }
  public string precipitation { get; set; }
  public string cloud_cover { get; set; }
  public string rain { get; set; }
  public string showers { get; set; }
  public string snowfall { get; set; }
 }

 public class currentReport
 {
  public DateTime time { get; set; }
  public int interval { get; set; }
  public int cloud_cover { get; set; }
  public double temperature_2m { get; set; }
  public double precipitation { get; set; }
  public double rain { get; set; }
  public double showers { get; set; }
  public double snowfall { get; set; }

 }

 public class hourUnits
 {
  public string time { get; set; }
  public string temperature_2m { get; set; }
  public string precipitation_probability { get; set; }
  public string wind_speed_10m { get; set; }
 }

 public class hourlyForecast
 {
  public List<DateTime> time { get; set; }
  public List<double> temperature_2m { get; set; }
  public List<int> precipitation_probability { get; set; }
  public List<double> wind_speed_10m { get; set; }
 }

 public class dailyUnits
 {
  public string time { get; set; }
  public string sunrise { get; set; }
  public string sunset { get; set; }
 }

 public class dailyStats
 {
  public List<DateTime> time { get; set; }
  public List<DateTime> sunrise { get; set; }
  public List<DateTime> sunset { get; set; }
 }

 public class WeatherForecast
 {
  public double latitude { get; set; }
  public double longitude { get; set; }
  public double generationtime_ms { get; set; }
  public int utc_offset_seconds { get; set; }
  public string timezone { get; set; }
  public string timezone_abbreviation { get; set; }
  public double elevation { get; set; }
  public UnitsDeclaration current_units { get; set; }
  public currentReport current { get; set; }
  public hourUnits hourly_units { get; set; }
  public hourlyForecast hourly { get; set; }
  public dailyUnits daily_units { get; set; }
  public dailyStats daily { get; set; }
 }
}
