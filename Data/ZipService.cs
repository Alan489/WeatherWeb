using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;

namespace Weather2EB.Data
{
 public class ZipService
 {
  private HttpClient _http;
  private NavigationManager _navi;

  public ZipService(HttpClient http, NavigationManager navi)
  {
   _http = http;
   _navi = navi;
  }

  public async Task<CityStruct?> getCityFromZip(string zip)
  {
   HttpResponseMessage response = await _http.GetAsync(_navi.BaseUri + "uszips.csv");
   string fileContent = await response.Content.ReadAsStringAsync();
   using (StringReader sr = new StringReader(fileContent))
   {
    string? line = null;
    while ((line = sr.ReadLine()) != null)
    {
     string[] items = line.Split(",");
     for (int i = 0; i < items.Length; i++)
      items[i] = items[i].Replace("\"", "");
     if (items[0] == zip)
     {
      CityStruct ret = new CityStruct();

      ret.lat = items[1];
      ret.lng = items[2];
      ret.City = items[3];
      ret.State = items[4];
      return ret;
     }
    }
   }

   return null;
  }

 }
}
