using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    public class InsDTO
    {
        public int Id { get; set; }
        public string date { get; set; }
        public string labDesc {get;set;}
        public string username { get; set; }
        public string status { get; set; } 
        //public string Title { get; set; }
        //public string AuthorName { get; set; }
    }
    public class InsDetDTO {
        public int Id { get; set; }
        public int? Inspectionid { get; set; }
        public string AreaEquip { get; set; }
    }
    public class HazObsDTO
    {
        public int Id { get; set; }
        public string HazardDesc { get; set; }
        public string Comm { get; set; }
        //public string Stats { get; set; }
    }
}