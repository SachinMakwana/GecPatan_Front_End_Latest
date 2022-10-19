using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Dynamic;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class HomeController : Controller
    {
        private string apiBaseUrl = "https://localhost:44374/api";
        HttpClient hc = new HttpClient();
        private static List<GalleryVM> galleryList = new List<GalleryVM>();
        private static List<NewsVM> newsList = new List<NewsVM>();

        RestClient client;
        public HomeController()
        {
            client = new RestClient(apiBaseUrl);
        }
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest6 = new RestRequest("/GetAllGalleryDetails", Method.Get);
            restRequest6.AddHeader("Accept", "application/json");
            restRequest6.RequestFormat = DataFormat.Json;

            RestResponse response6 = client.Execute(restRequest6);

            var content6 = response6.Content;
            if (content6 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<GalleryVM>>>(content6);
                galleryList = user.data;
                foreach (var data in galleryList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

            var restRequest = new RestRequest("/GetAllNewsDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content6 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<NewsVM>>>(content);
                newsList = user.data;
            }

            mymodel.newsList = newsList;
            mymodel.gallery = galleryList;

            return View(mymodel);
        }
    }
}