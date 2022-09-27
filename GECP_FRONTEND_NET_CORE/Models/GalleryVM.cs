using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GECP_FRONTEND_NET_CORE.Models
{
    public class GalleryVM
    {
        public GalleryVM()
        {
            InfrastructureList = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public int GalleryTagId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Image { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedDateInt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedDateInt { get; set; }
        public IList<SelectListItem> InfrastructureList { get; set; }
    }
}
