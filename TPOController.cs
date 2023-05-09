using BACKEND_HTML_DOT_NET.Models;
using GECP_DOT_NET_API.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Dynamic;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class TPOController : Controller
    {
        HttpClient hc = new HttpClient();
        private static List<CompanyVM> companyList = new List<CompanyVM>();
        private static List<VisionVM> visionVMList = new List<VisionVM>();
        private static List<MissionVM> missionVMList = new List<MissionVM>();
        private static List<PlacementDetailsVM> placementDetailsList = new List<PlacementDetailsVM>();

        RestClient client;
        private string apiBaseUrl = string.Empty;
        private string imageBaseUrl = string.Empty;
        public TPOController(IConfiguration configuration)
        {

            apiBaseUrl = configuration["AppIdentitySettings:apiBaseUrl"];
            imageBaseUrl = configuration["AppIdentitySettings:imageBaseUrl"];
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
                    data.Image = imageBaseUrl + data.Image;
                    data.Logo = imageBaseUrl + data.Logo;
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

            return View(placementDetailsList);
        }

        public IActionResult Graph(string number)
        {
            var restRequest = new RestRequest("/GetPlacementDetailsForGraph", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content4 = response.Content;
            if (content4 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<PlacementDetailsVM>>>(content4);
                placementDetailsList = user.data;
            }
            //var student = placementDetailsList.Where(m => m.IsDeleted != true).Select(s => new { s.PlacedStudent, s.PlacementYear }).GroupBy(m1 => m1.PlacementYear).ToList();
            //List<PlacementDetailsVM> student = null;
            //switch (number)
            //{
            //    case "chart0":
            //       student = placementDetailsList.Where(m => m.IsDeleted != true).GroupBy(s => s.PlacementYear).Select(group => new
            //                    {
            //                        PlacementYear = group.Key,
            //                        TotalPlacedStudents = group.Sum(s => s.PlacedStudent)
            //                    }).ToList();
            //        break;
            //}


            //return Json(student);
            List<PlacementDetailsVM> student = null;

            switch (number)
            {
                case "chart0":
                    student = placementDetailsList
                        .Where(m => m.IsDeleted != true)
                        .GroupBy(s => s.PlacementYear)
                        .Select(group => new PlacementDetailsVM
                        {
                            PlacementYear = group.Key,
                            PlacedStudent = group.Sum(s => s.PlacedStudent)
                        })
                        .ToList();
                    break;
                case "chart2":
                    student = placementDetailsList
                        .Where(m => m.IsDeleted != true)
                        .GroupBy(s => s.PlacementYear)
                        .Select(group => new PlacementDetailsVM
                        {
                            PlacementYear = group.Key,
                            HigestPackage = group.Max(s => s.HigestPackage)
                        })
                        .ToList();
                    break;

                case "chart3":
                    student = placementDetailsList
                        .Where(m => m.IsDeleted != true)
                        .GroupBy(s => s.PlacementYear)
                        .Select(group => new PlacementDetailsVM
                        {
                            PlacementYear = group.Key,
                            NoOfCompany = group.Sum(s => s.NoOfCompany)
                        })
                        .ToList();
                    break;

                case "chart4":
                    student = placementDetailsList
                        .Where(m => m.IsDeleted != true)
                        .GroupBy(s => s.PlacementYear)
                        .Select(group => new PlacementDetailsVM
                        {
                            PlacementYear = group.Key,
                            PlacedStudent = group.Sum(s => s.PlacedStudent),
                            NumberofRegisterdStudent = group.Sum(s => s.NumberofRegisterdStudent)
                        })
                        .ToList();
                    break;

                case "chart1":
                    student =  placementDetailsList
                        .Where(m => m.IsDeleted != true)
                        .GroupBy(s => s.DeptId)
                        .Select(group => new PlacementDetailsVM
                        {
                            DeptId = group.Key,
                            PlacedStudent = group.Sum(s => s.PlacedStudent),
                            
                        })
                        .ToList();
                    break;
            }

            return Json(student);

        }
    }
}