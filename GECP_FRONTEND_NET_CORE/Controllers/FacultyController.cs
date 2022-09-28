using BACKEND_HTML_DOT_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class FacultyController : Controller
    {
        private string apiBaseUrl = "https://localhost:44374/api";
        HttpClient hc = new HttpClient();
        private static List<FacultyDetailsVM> facultyList = new List<FacultyDetailsVM>();

        RestClient client;
        public FacultyController()
        {

            client = new RestClient(apiBaseUrl);
        }
        public IActionResult ComputerScience()
        {
            var restRequest5 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest5.AddHeader("Accept", "application/json");
            restRequest5.RequestFormat = DataFormat.Json;

            RestResponse response5 = client.Execute(restRequest5);

            var content5 = response5.Content;
            if (content5 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content5);
                facultyList = user.data;
                foreach (var data in facultyList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

            return View(facultyList);
        }
        public IActionResult Mechanical()
        {
            var restRequest5 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest5.AddHeader("Accept", "application/json");
            restRequest5.RequestFormat = DataFormat.Json;

            RestResponse response5 = client.Execute(restRequest5);

            var content5 = response5.Content;
            if (content5 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content5);
                facultyList = user.data;
                foreach (var data in facultyList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

            return View(facultyList);
        }
        public IActionResult Electrical()
        {
            var restRequest5 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest5.AddHeader("Accept", "application/json");
            restRequest5.RequestFormat = DataFormat.Json;

            RestResponse response5 = client.Execute(restRequest5);

            var content5 = response5.Content;
            if (content5 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content5);
                facultyList = user.data;
                foreach (var data in facultyList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

            return View(facultyList);
        }
        public IActionResult ElectronicsCommunication()
        {
            var restRequest5 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest5.AddHeader("Accept", "application/json");
            restRequest5.RequestFormat = DataFormat.Json;

            RestResponse response5 = client.Execute(restRequest5);

            var content5 = response5.Content;
            if (content5 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content5);
                facultyList = user.data;
                foreach (var data in facultyList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

            return View(facultyList);
        }
        public IActionResult Civil()
        {
            var restRequest5 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest5.AddHeader("Accept", "application/json");
            restRequest5.RequestFormat = DataFormat.Json;

            RestResponse response5 = client.Execute(restRequest5);

            var content5 = response5.Content;
            if (content5 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content5);
                facultyList = user.data;
                foreach (var data in facultyList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

            return View(facultyList);
        }
        public IActionResult FacultyView(int id)
        {
            foreach(var faculty in facultyList)
            {
                if(faculty.Id == id)
                {
                    return View(faculty);
                }
            }
            return NotFound();
        }
    }
}
