using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Dynamic;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class TPOController : Controller
    {
        private string apiBaseUrl = "https://localhost:44374/api";
        HttpClient hc = new HttpClient();
        private static List<CompanyVM> companyList = new List<CompanyVM>();
        private static List<VisionVM> visionVMList = new List<VisionVM>();
        private static List<MissionVM> missionVMList = new List<MissionVM>();

        RestClient client;
        public TPOController()
        {
            client = new RestClient(apiBaseUrl);
        }
        public IActionResult Overview()
        {
            var restRequest = new RestRequest("/GetAllCompanyDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<CompanyVM>>>(content);
                companyList = user.data;
                foreach (var data in companyList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                    data.Logo = "https://localhost:44374/" + data.Logo;
                }
            }
            return View(companyList);
        }
        public IActionResult VissionMission()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest2 = new RestRequest("/GetAllVisionDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;
            if (content2 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<VisionVM>>>(content2);
                visionVMList = user.data;
            }

            var restRequest3 = new RestRequest("/GetAllMissionDetails", Method.Get);
            restRequest3.AddHeader("Accept", "application/json");
            restRequest3.RequestFormat = DataFormat.Json;

            RestResponse response3 = client.Execute(restRequest3);

            var content3 = response3.Content;
            if (content3 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<MissionVM>>>(content3);
                missionVMList = user.data;
            }

            mymodel.vision = visionVMList;
            mymodel.mission = missionVMList;
            return View(mymodel);
        }
        public IActionResult Placements()
        {
            return View();
        }
        public IActionResult Graphview()
        {
            return View();
        }
    }
}