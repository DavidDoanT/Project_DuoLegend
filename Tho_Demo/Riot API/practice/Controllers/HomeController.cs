using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using practice.ViewModels;
using Newtonsoft.Json;

namespace practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    

        public IActionResult check()
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

            

            checkViewModel infor = new checkViewModel();
            infor.test = stuff.freeChampionIds[1];
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return View(infor);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
