using ImagePrediction.Models;
using ImagePrediction.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePrediction.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(new ResultViewModel());

        [HttpPost]
        public async Task<IActionResult> Index(string image)
        {
            //var url = "https://customvisiongeov-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/b1a9d088-c7e3-4825-bc29-81060296feb2/classify/iterations/Iteration1%20-%20Published/url";
            //var token = "d66602cd458f42b1bccdf6a4fffbe8c5";
            var url = "https://customvisiontcc-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/a16bc297-7352-4389-9877-ae6f3af3d120/classify/iterations/Cafe%20-%20Published%20Iteration10/url";
            var token = "79f52af92e574742ad1414dd89afbc54";
            var customVision = new Classification(url, token);
            var result = await customVision.Detect(image);

            
            return View("Index", new ResultViewModel
            {
                Label = result,
                Url = image,

            });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ferrugem()
        {
            return View();
        }

        public IActionResult Cercosporiose()
        {
            return View();
        }

        public IActionResult ManchaAureolada()
        {
            return View();
        }
    }
}
