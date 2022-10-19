using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class AboutController : Controller
    {
        HttpClient hc = new HttpClient();
        RestClient client;

        private string apiBaseUrl = string.Empty;
        private string imageBaseUrl = string.Empty;
        public AboutController(IConfiguration configuration)
        {

            apiBaseUrl = configuration["AppIdentitySettings:apiBaseUrl"];
            imageBaseUrl = configuration["AppIdentitySettings:imageBaseUrl"];
            client = new RestClient(apiBaseUrl);
        }

        public async Task<IActionResult> VisionMission()
        {
            List<VisionVM> visionVM = new List<VisionVM>();
            List<MissionVM> missionVM = new List<MissionVM>();

            var restRequest = new RestRequest("/GetAllVisionDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;

            var user = JsonConvert.DeserializeObject<ServiceResponse<List<VisionVM>>>(content);
            visionVM = user.data;

            var restRequest2 = new RestRequest("/GetAllMissionDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;

            var user2 = JsonConvert.DeserializeObject<ServiceResponse<List<MissionVM>>>(content2);
            missionVM = user2.data;

            VissionMissionVM data = new VissionMissionVM();
            data.vission = visionVM.Where(m => m.DeptId == 2).FirstOrDefault().Description;
            data.mission = missionVM.Where(m => m.DeptId == 2).FirstOrDefault().Description;


            return View(data);
        }
        public IActionResult Infrastructure()
        {
            List<GalleryVM> galleryVM = new List<GalleryVM>();
            List<GalleryVM> galleryVM2 = new List<GalleryVM>();

            GalleryVM infrastructureImg = new GalleryVM();

            var restRequest = new RestRequest("/GetAllGalleryDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<GalleryVM>>>(content);
                galleryVM = user.data;
                foreach (var data in galleryVM)
                {
                    if (data.GalleryTagId == 100)
                    {
                        galleryVM2.Add(data);
                    }
                }
            }
            foreach (var data in galleryVM2)
            {
                data.Image = imageBaseUrl + data.Image;
            }

            return View(galleryVM2);
        }
        public IActionResult Principal()
        {
            List<CollegeVM> collegeVM = new List<CollegeVM>();
            var restRequest = new RestRequest("/GetCollegeDetail", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;

            var user = JsonConvert.DeserializeObject<ServiceResponse<List<CollegeVM>>>(content);
            collegeVM = user.data;
            return View(collegeVM);
        }
        public IActionResult Overview()
        {
            List<CollegeVM> collegeVM = new List<CollegeVM>();
            var restRequest = new RestRequest("/GetCollegeDetail", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;

            var user = JsonConvert.DeserializeObject<ServiceResponse<List<CollegeVM>>>(content);
            foreach (var data in collegeVM)
            {
                data.Image = "https://localhost:44374/" + data.Image;
            }
            collegeVM = user.data;
            return View(collegeVM);
        }
    }
}