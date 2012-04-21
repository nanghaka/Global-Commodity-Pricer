using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CommodityAPI.Models
{
    public class UnitMeasure
    {
        [Key]
        public int UnitMeasureID { get; set; }
        public string UnitName { get; set; }
        public string ShortForm { get; set; }
    }
}
