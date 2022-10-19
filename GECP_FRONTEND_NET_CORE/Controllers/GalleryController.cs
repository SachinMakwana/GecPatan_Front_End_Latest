using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class GalleryController : Controller
    {
        
        HttpClient hc = new HttpClient();
        private static List<GalleryVM> galleryList = new List<GalleryVM>();

        RestClient client;
        private string apiBaseUrl = string.Empty;
        private string imageBaseUrl = string.Empty;
        public GalleryController(IConfiguration configuration)
        {

            apiBaseUrl = configuration["AppIdentitySettings:apiBaseUrl"];
            imageBaseUrl = configuration["AppIdentitySettings:imageBaseUrl"];
            client = new RestClient(apiBaseUrl);
        }
       
        public IActionResult Gallery()
        {
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
                    data.Image = imageBaseUrl + data.Image;
                }
            }
            return View(galleryList);
        }
    }
}
