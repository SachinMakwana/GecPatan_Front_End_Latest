using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Dynamic;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class CoursesController : Controller
    {
        
        HttpClient hc = new HttpClient();
        private static List<DepartmentVM> departmentVMList = new List<DepartmentVM>();
        private static List<FacultyDetailsVM> facultyVMList = new List<FacultyDetailsVM>();

        RestClient client;
        private string apiBaseUrl = string.Empty;
        private string imageBaseUrl = string.Empty;
        public CoursesController(IConfiguration configuration)
        {

            apiBaseUrl = configuration["AppIdentitySettings:apiBaseUrl"];
            imageBaseUrl = configuration["AppIdentitySettings:imageBaseUrl"];
            client = new RestClient(apiBaseUrl);
        }
      
        public IActionResult ComputerScience()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest = new RestRequest("/GetAllDepartmentDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<DepartmentVM>>>(content);
                departmentVMList = user.data;
                foreach (var data in departmentVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            var restRequest2 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;
            if (content2 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content2);
                facultyVMList = user.data;
                foreach (var data in facultyVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            mymodel.departmentVM = departmentVMList;
            mymodel.facultyVMList = facultyVMList;

            return View(mymodel);
        }
        public IActionResult Mechanical()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest = new RestRequest("/GetAllDepartmentDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<DepartmentVM>>>(content);
                departmentVMList = user.data;
                foreach (var data in departmentVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            var restRequest2 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;
            if (content2 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content2);
                facultyVMList = user.data;
                foreach (var data in facultyVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            mymodel.departmentVM = departmentVMList;
            mymodel.facultyVMList = facultyVMList;

            return View(mymodel);
        }
        public IActionResult Electrical()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest = new RestRequest("/GetAllDepartmentDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<DepartmentVM>>>(content);
                departmentVMList = user.data;
                foreach (var data in departmentVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            var restRequest2 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;
            if (content2 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content2);
                facultyVMList = user.data;
                foreach (var data in facultyVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            mymodel.departmentVM = departmentVMList;
            mymodel.facultyVMList = facultyVMList;

            return View(mymodel);
        }
        public IActionResult ElectronicsCommunication()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest = new RestRequest("/GetAllDepartmentDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<DepartmentVM>>>(content);
                departmentVMList = user.data;
                foreach (var data in departmentVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            var restRequest2 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;
            if (content2 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content2);
                facultyVMList = user.data;
                foreach (var data in facultyVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            mymodel.departmentVM = departmentVMList;
            mymodel.facultyVMList = facultyVMList;

            return View(mymodel);
        }
        public IActionResult Civil()
        {
            dynamic mymodel = new ExpandoObject();

            var restRequest = new RestRequest("/GetAllDepartmentDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<DepartmentVM>>>(content);
                departmentVMList = user.data;
                foreach (var data in departmentVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            var restRequest2 = new RestRequest("/GetAllFacultyDetails", Method.Get);
            restRequest2.AddHeader("Accept", "application/json");
            restRequest2.RequestFormat = DataFormat.Json;

            RestResponse response2 = client.Execute(restRequest2);

            var content2 = response2.Content;
            if (content2 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<FacultyDetailsVM>>>(content2);
                facultyVMList = user.data;
                foreach (var data in facultyVMList)
                {
                    data.Image = imageBaseUrl + data.Image;
                }
            }

            mymodel.departmentVM = departmentVMList;
            mymodel.facultyVMList = facultyVMList;

            return View(mymodel);
        }
    }
}
