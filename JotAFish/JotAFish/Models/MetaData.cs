using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace JotAFish.Models
{
    public class MetaData
    {
        GetPastWeather getPastWeather = new GetPastWeather();
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string datetime { get; set; }
        public List<string> date { get; set; }
        public List<string> latList { get; set; }
        public List<string> lngList { get; set; }
        public string time { get; set; }
        public string dateNoTime { get; set; }
        public string newFileName { get; set; }
        public string imagePath { get; set; }
        public string newLocation { get; set; }
        public object pastWeather { get; set; }
        public List<object> newpastWeather { get; set; }
        public List<string> newString { get; set; }
        public bool decide = false;
        int counter = 0;

        public void uploadImg()
        {
            WebImage photo = null;
            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);
                imagePath = @"images/" + newFileName;
                photo.Save(@"~/" + imagePath);
            }
            newLocation = "images/" + newFileName;
            if (newFileName != null) { extractDateAndTime(); }
        }
        string address = "C:/Users/Kao/Documents/devcodecamp projects/JotAFish/JotAFish/JotAFish/";
        public void addPathToList(List<string> paths)
        {
            newpastWeather = new List<object>();
            newString = new List<string>();
            foreach (string addres in paths)
            {
                counter++;
                newString.Add(addres);
            }
            if (newString == null) { return; }
            else {
                extractDateAndTime();
            }
        }
        public void extractDateAndTime()
        {
            //date = new List<string>();
            //if (newString == null) { decide = false; } else { decide = true; }
            //if (decide == true)
            //{
            //    foreach (string loc in newString)
            //    {
            //        IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(loc);
            //        foreach (var directory in directories)
            //        {
            //            foreach (var tag in directory.Tags)
            //            {
            //                if (tag.Name == "Date/Time")
            //                {
            //                    datetime = tag.Description;
            //                    foreach (char item in datetime)
            //                    {
            //                        if (char.IsWhiteSpace(item))
            //                        {
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            dateNoTime = dateNoTime + item;
            //                            dateNoTime = dateNoTime.Replace(":", "-");
            //                        }
            //                    }
            //                }
            //                //[DO NOT DELETE, USE FOR REFERENCE!]
            //                //Console.WriteLine($"{directory.Name} - {tag.TagName} = {tag.Description}");
            //            }
            //        }
            //        extractLatLong();
            //        //return dateNoTime;
            //    }
            //}
            //else
            //{
            date = new List<string>();
            if (newString != null)
            {
                foreach (var paths in newString)
                {
                    dateNoTime = "";
                    IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(paths);

                    foreach (var directory in directories)
                    {
                        foreach (var tag in directory.Tags)
                        {
                            if (tag.Name == "Date/Time")
                            {
                                datetime = tag.Description;
                                foreach (char item in datetime)
                                {
                                    if (char.IsWhiteSpace(item))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        dateNoTime += item;
                                        dateNoTime = dateNoTime.Replace(":", "-");

                                    }
                                }
                            }
                            //[DO NOT DELETE, USE FOR REFERENCE!]
                            //Console.WriteLine($"{directory.Name} - {tag.TagName} = {tag.Description}");
                        }
                    }
                    //return dateNoTime;
                    date.Add(dateNoTime);
                }
                extractLatLong();
            }
        }
        public void extractLatLong()
        {
            File.WriteAllText("C:/Users/Kao/Documents/devcodecamp projects/JotAFish/JotAFish/JotAFish/Kao.json", "");
            latList = new List<string>();
            lngList = new List<string>();
            //if (newString != null)
            //{
            //    foreach (string loc in newString)
            //    {
            //        if (decide == true)
            //        {
            //            var gps = ImageMetadataReader.ReadMetadata(loc)
            //                        .OfType<GpsDirectory>()
            //                        .FirstOrDefault();

            //            var location = gps.GetGeoLocation();
            //            Lat = location.Latitude;
            //            Lng = location.Longitude;

            //            //var latlng = new Tuple<double, double>(lat,lng);
            //            //Console.WriteLine(latlng);
            //            //return latlng;
            //            var extra = gps.Tags;
            //            foreach (var item in extra)
            //            {
            //                if (item.Name == "GPS Date Stamp")
            //                {
            //                    date = item.Description;
            //                    Console.WriteLine(date);
            //                }
            //                else if (item.Name == "GPS Time-Stamp")
            //                {
            //                    time = item.Description;
            //                    Console.WriteLine(time);
            //                }
            //            }
            //            newpastWeather = new List<object>();
            //            pastWeather = getPastWeather.getWeatherForcast(Lat.ToString(), Lng.ToString(), dateNoTime);
            //            newpastWeather.Add(pastWeather);
            //        }
            //    }
            //}
            //if (decide == false)
            //{

            foreach (var add in newString)
            {
                
                Lat = 0;
                Lng = 0;

                var gps = ImageMetadataReader.ReadMetadata(add)
                                 .OfType<GpsDirectory>()
                                 .FirstOrDefault();

                var location = gps.GetGeoLocation();
                Lat = location.Latitude;
                Lng = location.Longitude;



                latList.Add(Lat.ToString());
                lngList.Add(Lng.ToString());

                //var latlng = new Tuple<double, double>(lat,lng);
                //Console.WriteLine(latlng);
                //return latlng;
                //var extra = gps.Tags;
                //foreach (var item in extra)
                //{
                //    if (item.Name == "GPS Date Stamp")
                //    {
                //        date = item.Description;
                //        //Console.WriteLine(date);
                //    }
                //    else if (item.Name == "GPS Time-Stamp")
                //    {
                //        time = item.Description;
                //        //Console.WriteLine(time);
                //    }

                //}

                newpastWeather.Add(getPastWeather.getWeatherForcast(Lat.ToString(), Lng.ToString(), dateNoTime));
                //extractLatLong();
                //newpastWeather.Add(pastWeather);


                Coord coord = new Coord(Lat.ToString(),Lng.ToString());

                //string name = "Kao";
                string locationName = "C:/Users/Kao/Documents/devcodecamp projects/JotAFish/JotAFish/JotAFish/Kao.json";
                string reader = "";
                string output = "";
                

                FileInfo fInfo = new FileInfo(locationName);
                if (!fInfo.Exists)
                {
                    File.WriteAllText(locationName, output);
                }
                else
                {
                    reader = File.ReadAllText(locationName);
                }

                List<Coord> coordInfo = JsonConvert.DeserializeObject<List<Coord>>(reader);
                if (coordInfo == null)
                {
                    coordInfo = new List<Coord>();
                }
                coordInfo.Add(coord);
                output = JsonConvert.SerializeObject(coordInfo, Formatting.Indented);
                File.WriteAllText(locationName, output);
            }
        }
    }
}
