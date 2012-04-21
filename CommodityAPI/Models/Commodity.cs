using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommodityAPI.Models
{
    public class Commodity
    {
        [Key]
        public virtual int CommodityID { get; set; }
        public virtual string CommodityName { get; set; }
        public virtual decimal CommodityPrice { get; set; }

        public virtual DateTime DateTimeSubmitted { get; set; }
        public virtual string User { get; set; }


        public virtual int UnitMeasureID { get; set; }
        public virtual UnitMeasure Units { get; set; }


        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
    }
}