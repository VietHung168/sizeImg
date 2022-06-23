using CanHinhAnh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CanHinhAnh.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //using (WebClient webClient = new WebClient())
            //{
            //    //  FileInfo fi = new FileInfo("https://cdn.tgdd.vn//content/Untitled-1-150x150-4.png");
            //    byte[] data1 = webClient.DownloadData("https://cdn.tgdd.vn//content/Untitled-1-150x150-4.png");
            //    int ssss = data1.Length/1024;
            //    Console.WriteLine(ssss);
            //}
            // string ssss= fi.Length.ToString();
          //  Console.WriteLine(ssss);
            using (System.Net.WebClient web1 = new WebClient())
            {
         string data = web1.DownloadString("https://www.avakids.com/ta-cho-be");
                cao c = new cao();

                ViewBag.str = c.Crawl(data);
            }
               
           // Console.WriteLine(data);
        
       
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult check(string link)
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
