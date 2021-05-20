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


        [HttpPost]
        public IActionResult Checkout(inputData input)
        {
       

               WebRequest request = WebRequest.Create("https://br1.api.riotgames.com/lol/summoner/v4/summoners/by-name/"+input.ingameName+ "?api_key=RGAPI-805b3391-221c-44fa-9dad-339bed17c9b1");
            
            
            // Get the response.
            try
            {
                checkViewModel infor = new checkViewModel();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);

                dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);



                
                infor.level = stuff.summonerLevel;
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();
                return View(infor);
            }
            catch (Exception)
            {
                checkViewModel infor = new checkViewModel();
                infor.level = 0;
                return View(infor);
            }
            

            // Get the stream containing content returned by the server.
            
            // Open the stream using a StreamReader for easy access.
            
            // Read the content.

        }


        public IActionResult formTest()
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
