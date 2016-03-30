using JotAFish.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;

namespace JotAFish.Controllers
{
    public class UploadController : Controller
    {
        List<string> pathList = new List<string>();
        //GET: Upload
        public ActionResult UploadImage()
        {
            MetaData mdImg = new MetaData();
            mdImg.uploadImg();
            ViewBag.newFileName = mdImg.newFileName;
            ViewBag.newLocation = mdImg.newLocation;
            ViewBag.imagePath = mdImg.imagePath;
            ViewBag.Date = mdImg.dateNoTime;
            ViewBag.Lat = mdImg.Lat;
            ViewBag.Lng = mdImg.Lng;
            ViewBag.PastWeather = mdImg.pastWeather;
            var myPics = new MyPictures();
            {
                myPics.Images = Directory.EnumerateFiles(Server.MapPath("/images/"))
                                  .Select(fn => "/images/" + Path.GetFileName(fn));
            }
            ViewBag.P = myPics.Images;
            foreach (var image in ViewBag.P)
            {
                pathList.Add("C:/Users/Kao/Documents/devcodecamp projects/JotAFish/JotAFish/JotAFish"+image);
            }
            mdImg.addPathToList(pathList);
            ViewBag.list = pathList;
            ViewBag.info = mdImg.newpastWeather;
            ViewBag.date = mdImg.date;
            return View();
        }
        public ActionResult ViewMyPictures()
        {
          
            return View();
        }
    }
}