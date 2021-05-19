using DemoValidIngame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace DemoValidIngame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object JsonConvert { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Infor infor)
        {
            WebRequest request = WebRequest.Create("https://br1.api.riotgames.com/lol/platform/v3/champion-rotations?api_key=RGAPI-df10c379-2929-4ebb-8c86-6ea397b0cba1");

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);

            dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);



            
            
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();


            return View(order);
        }


    }
}
