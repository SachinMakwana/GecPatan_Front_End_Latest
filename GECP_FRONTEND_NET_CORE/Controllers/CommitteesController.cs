using BACKEND_HTML_DOT_NET.Models;
using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Dynamic;
using System.Linq;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class CommitteesController : Controller
    {
        private string apiBaseUrl = "https://localhost:44374/api";
        HttpClient hc = new HttpClient();
        private static List<CommitteeVM> committeeVMList = new List<CommitteeVM>();
        private static List<VisionVM> visionVMList = new List<VisionVM>();
        private static List<MissionVM> missionVMList = new List<MissionVM>();
        private static List<CommitteeMembersVM> memberList = new List<CommitteeMembersVM>();
        private static List<FacultyDetailsVM> facultyList = new List<FacultyDetailsVM>();
        private static List<GalleryVM> galleryList = new List<GalleryVM>();


        RestClient client;
        public CommitteesController()
        {
            client = new RestClient(apiBaseUrl);
        }
        public IActionResult WomenCell()
        {
            dynamic mymodel = new ExpandoObject();
            List<CommitteeMembersVM> womencellMembers = new List<CommitteeMembersVM>();
            List<FacultyDetailsVM> womencellFaculty = new List<FacultyDetailsVM>();
            List<GalleryVM> womencellgallery = new List<GalleryVM>();


            var restRequest = new RestRequest("/GetAllCommitteeDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<CommitteeVM>>>(content);
                committeeVMList = user.data;
                foreach (var data in committeeVMList)
                {
                    data.Image = "https://localhost:44374/" + data.Image;
                }
            }

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

            var restRequest4 = new RestRequest("/GetAllCommitteeMembersDetails", Method.Get);
            restRequest4.AddHeader("Accept", "application/json");
            restRequest4.RequestFormat = DataFormat.Json;

            RestResponse response4 = client.Execute(restRequest4);

            var content4 = response4.Content;
            if (content4 != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<CommitteeMembersVM>>>(content4);
                memberList = user.data;
                
            }

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

            mymodel.committe = committeeVMList;
            mymodel.facultyList = facultyList;
            mymodel.vision = visionVMList;
            mymodel.mission = missionVMList;
            mymodel.gallery = galleryList;
            mymodel.members = memberList;

            return View(mymodel);
        }
    }
}
