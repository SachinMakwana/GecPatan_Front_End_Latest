using System;
using System.Collections.Generic;

namespace GECP_FRONTEND_NET_CORE.Models
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedDateInt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedDateInt { get; set; }
    }
}
