using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace JotAFish.Models
{
    public class GetPastWeather
    {
        //string date;
        public object getWeatherForcast(string Lat, string Lng, string Date)
        {
            
            string latitude = Lat;
            string longitude = Lng;

         

            string ll = latitude + "," + longitude;
            string url = "http://";
            string here = url + "api.worldweatheronline.com/premium/v1/past-weather.ashx?key=b145f63e744541b3a51195857162903&q=" + ll + "&format=json&cc=no&date="+Date+"&tp=24";

            var client = new WebClient();
            var content = client.DownloadString(here);
            //var serializer = new JavaScriptSerializer();
            //var jsonContent = serializer.Deserialize<Object>(content);
            //var test = JsonConvert.SerializeObject(jsonContent, Formatting.Indented);
            PastWeather x = JsonConvert.DeserializeObject<PastWeather>(content);

            var s = x.data.weather;


            //File.WriteAllText("C:/Users/Kao/Documents/devcodecamp projects/usethisweather/usethisweather/test2.json", test);


            return s;
        }
    }
}