using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Text;
using System.Threading.Tasks;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class AboutController : Controller
    {
        private string apiBaseUrl = "https://localhost:44374/api";
        HttpClient hc = new HttpClient();
        

        RestClient client;
        public AboutController()
        {
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
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }
        public IActionResult Overview()
        {
            return View();
        }
    }
}
